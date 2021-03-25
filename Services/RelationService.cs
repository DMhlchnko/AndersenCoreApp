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
        private readonly IRelationRepository _relationRepo;
        private readonly ICountryRepository _countryRepo;
        private readonly IRelationAddressRepository _relationAddressRepo;
        private readonly IMapper _mapper;
        private readonly IPostalCodeFormatter _formatter;

        public RelationService(IRelationRepository relations, ICountryRepository countries,
            IMapper mapper, IPostalCodeFormatter formatter, IRelationAddressRepository relationAddresses)
        {
            _relationRepo = relations;
            _countryRepo = countries;
            _relationAddressRepo = relationAddresses;
            _mapper = mapper;
            _formatter = formatter;
        }

        /// <inheritdoc />
        public async Task<bool> CheckRelationExistenceAsync(Guid relationId)
        {
            var result = await _relationRepo.HasAnyAsync(relationId);
            return result;
        }

        /// <inheritdoc />
        public async Task<RelationDTO> GetOneAsync(Guid id)
        {
            var relation = await _relationRepo.GetOneAsync(id);
            var relationsViewModel = _mapper.Map<RelationDTO>(relation);

            return relationsViewModel;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RelationDTO>> GetRelationsAsync(RelationFilter filter)
        {
            var relations = await _relationRepo.GetAllAsync(filter);
            var relationViewModels = _mapper.Map<IEnumerable<RelationDTO>>(relations);

            return relationViewModels;
        }

        /// <inheritdoc />
        public async Task<RelationDTO> CreateAsync(RelationDTO relation)
        {
            if(relation == null)
            {
                throw new AgrumentNullException($"{nameof(relation)} is null.");
            }
            var country = await _countryRepo.GetOneAsync(relation.Country);
            if(country == null)
            {
                throw new AgrumentNullException($"{nameof(country)} is null.");
            }
            var postalCodeFormat = country.PostalCodeFormat;
            var postalCode = relation.PostalCode;
            relation = _formatter.ApplyPostalCodeMask(relation, postalCodeFormat, postalCode);
            var relationAddress = await _relationAddressRepo.CreateAsync(relation.City, relation.Street,
                        relation.StreetNumber, relation.PostalCode, country.Id);
            relationToCreate = new Relation
                    {
                        Id = relation.Id,
                        Name = relation.Name,
                        FullName = relation.FullName,
                        TelephoneNumber = relation.TelephoneNumber,
                        EmailAddress = relation.EMail,
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
            relationToCreate = await _relationRepo.CreateAsync(relationToCreate);
                    relation = _mapper.Map<RelationDTO>(relationToCreate);

            return relation;
        }

        /// <inheritdoc />
        public async Task<RelationDTO> UpdateAsync(RelationDTO relation)
        {
            if (relation != null)
            {
                var country = await _countryRepo.GetOneAsync(relation.Country);
                var relationToUpdate = await _relationRepo.GetOneAsync(relation.Id);
                var postalCodeFormat = country.PostalCodeFormat ?? "";
                var postalCode = relation.PostalCode;
                relation = _formatter.ApplyPostalCodeMask(relation, postalCodeFormat, postalCode);
                var updatedRelationAddress = await _relationAddressRepo.UpdateAsync(relation.City, relation.Street,
                    relation.StreetNumber, relation.PostalCode, relationToUpdate.RelationAddressId);
                relationToUpdate.Name = relation.Name;
                relationToUpdate.FullName = relation.FullName;
                relationToUpdate.TelephoneNumber = relation.TelephoneNumber;
                relationToUpdate.EmailAddress = relation.EMail;
                relationToUpdate.RelationAddress = updatedRelationAddress;
                relationToUpdate = await _relationRepo.UpdateAsync(relationToUpdate);
                relation = _mapper.Map<RelationDTO>(relationToUpdate);
            }

            return relation;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RelationDTO>> DeleteAsync(params Guid[] identificators)
        {

            List<RelationDTO> deletedRelations = new List<RelationDTO>();
            var relations = await _relationRepo.DeleteAsync(identificators);
            foreach(var relation in relations)
            {
                var relationDTO = _mapper.Map<RelationDTO>(relation);
                deletedRelations.Add(relationDTO);
            }
            return deletedRelations;
        }
      
    }
}
