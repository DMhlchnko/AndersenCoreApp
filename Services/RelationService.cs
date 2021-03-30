using AndersenCoreApp.Exceptions;
using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Interfaces.Formatters;
using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Services
{
    /// <inheritdoc />
    public class RelationService : IRelationService
    {
        private readonly IRelationRepository _relationRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IRelationAddressRepository _relationAddressRepository;
        private readonly IMapper _mapper;
        private readonly IPostalCodeFormatter _formatter;

        /// <summary>
        /// Constructor of the RelationService.
        /// </summary>
        public RelationService(IRelationRepository relations,
            ICountryRepository countries,
            IMapper mapper,
            IPostalCodeFormatter formatter,
            IRelationAddressRepository relationAddresses)
        {
            _relationRepository = relations;
            _countryRepository = countries;
            _relationAddressRepository = relationAddresses;
            _mapper = mapper;
            _formatter = formatter;
        }

        /// <inheritdoc />
        public async Task<bool> CheckRelationExistenceAsync(Guid relationId)
        {
            var result = await _relationRepository.HasAnyAsync(relationId);
            return result;
        }

        /// <inheritdoc />
        public async Task<RelationDTO> GetOneAsync(Guid id)
        {
            var relation = await _relationRepository.GetOneAsync(id);
            var relationsViewModel = _mapper.Map<RelationDTO>(relation);

            return relationsViewModel;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RelationDTO>> GetRelationsAsync(RelationFilter filter)
        {
            var relations = await _relationRepository.GetAllAsync(filter);
            var relationViewModels = _mapper.Map<IEnumerable<RelationDTO>>(relations);

            return relationViewModels;
        }

        /// <inheritdoc />
        public async Task<RelationDTO> CreateAsync(RelationDTO relation)
        {
            if (relation == null)
            {
                throw new ArgumentNullException($"{nameof(relation)} is null.");
            }
            
            //1. Getting country for inputed relation.
            var country = await _countryRepository.GetOneAsync(relation.Country);
            if (country == null)
            {
                throw new NullException($"{nameof(country)} is null.");
            }

            //2. Applying postal code mask for relation.
            var postalCodeFormat = country.PostalCodeFormat;
            _formatter.ApplyPostalCodeMask(relation, postalCodeFormat);

            //3.Creating relation address for inputed relation.
            var relationAddress = await _relationAddressRepository.CreateAsync(relation, country.Id);

            //4. Creating new Relation.
            var relationToCreate = new Relation
            {
                Name = relation.Name,
                FullName = relation.FullName,
                TelephoneNumber = relation.TelephoneNumber,
                EmailAddress = relation.Email,
                RelationAddressId = relationAddress.Id,
                RelationAddress = relationAddress,
                CreatedAt = DateTime.Now,
                CreatedBy = "admin",
                IsDisabled = false,
                IsMe = false,
                IsTemporary = false,
                PaymentViaAutomaticDebit = false,
                InvoiceDateGenerationOptions = 1,
                InvoiceGroupByOptions = 1
            };

            //5. Adding new Relation to the database.
            relationToCreate = await _relationRepository.CreateAsync(relationToCreate);
            relation = _mapper.Map<RelationDTO>(relationToCreate);

            return relation;
        }

        /// <inheritdoc />
        public async Task<RelationDTO> UpdateAsync(RelationDTO relation)
        {
            if (relation == null)
            {
                throw new ArgumentNullException($"{nameof(relation)} is null.");
            }

            //1. Getting country for inputed relation.
            var country = await _countryRepository.GetOneAsync(relation.Country);
            if (country == null)
            {
                throw new NullException($"{nameof(country)} is null.");
            }

            //2. Getting relation for updating.
            var relationToUpdate = await _relationRepository.GetOneAsync(relation.Id);

            //3. Applying postal code mask for relation.
            var postalCodeFormat = country.PostalCodeFormat;
            _formatter.ApplyPostalCodeMask(relation, postalCodeFormat);

            //3.Updating relation address for inputed relation.
            var relationAddressToUpdate = await _relationAddressRepository.UpdateAsync(relation,relationToUpdate.RelationAddressId);

            //4. Updating relation properties.
            relationToUpdate.Name = relation.Name;
            relationToUpdate.FullName = relation.FullName;
            relationToUpdate.TelephoneNumber = relation.TelephoneNumber;
            relationToUpdate.EmailAddress = relation.Email;
            relationToUpdate.RelationAddress = relationAddressToUpdate;

            //5. Updating relation in database.
            relationToUpdate = await _relationRepository.UpdateAsync(relationToUpdate);
            relation = _mapper.Map<RelationDTO>(relationToUpdate);

            return relation;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RelationDTO>> DeleteAsync(params Guid[] identificators)
        {

            List<RelationDTO> deletedRelations = new List<RelationDTO>();
            var relations = await _relationRepository.DeleteAsync(identificators);
            foreach(var relation in relations)
            {
                var relationDTO = _mapper.Map<RelationDTO>(relation);
                deletedRelations.Add(relationDTO);
            }
            return deletedRelations;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CountryDTO>> GetCoutryList()
        {
            var countries = await _countryRepository.GetAllAsync();
            var countriesDTO = _mapper.Map<IEnumerable<CountryDTO>>(countries);
            return countriesDTO;
        }
    }
}
