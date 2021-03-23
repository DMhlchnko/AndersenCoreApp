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
        private readonly IMapper _mapper;
        private readonly IPostalCodeFormatter _formatter;

        public RelationService(IRelationRepository relations, ICountryRepository countries, IMapper mapper, IPostalCodeFormatter formatter)
        {
            _relationRepo = relations;
            _countryRepo = countries;
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
            Country country;
            string postalCodeFormat;
            string postalCode;
            Relation relationToCreate;
            if (relation != null)
            {
                country = await _countryRepo.GetOneAsync(relation.Country);
                postalCodeFormat = country.PostalCodeFormat;
                postalCode = relation.PostalCode;
                relation = _formatter.ApplyPostalCodeMask(relation, postalCodeFormat, postalCode);
            }
            relationToCreate = await _relationRepo.CreateAsync(_mapper.Map<Relation>(relation));
            relation = _mapper.Map<RelationDTO>(relationToCreate);
            return relation;
        }

        /// <inheritdoc />
        public async Task<RelationDTO> UpdateAsync(RelationDTO relation)
        {
            Country country;
            string postalCodeFormat;
            string postalCode;
            Relation updatedRelation;
            if (relation != null)
            {
                country = await _countryRepo.GetOneAsync(relation.Country);
                postalCodeFormat = country.PostalCodeFormat;
                postalCode = relation.PostalCode;
                relation = _formatter.ApplyPostalCodeMask(relation, postalCodeFormat, postalCode);
            }
            updatedRelation = _mapper.Map<Relation>(relation);
            updatedRelation = await _relationRepo.UpdateAsync(updatedRelation);
            relation = _mapper.Map<RelationDTO>(updatedRelation);
            return relation;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RelationDTO>> DeleteAsync(params Guid[] identificators)
        {
            var relations = await _relationRepo.DeleteAsync(identificators);
            var deletedRelations = _mapper.Map<IEnumerable<RelationDTO>>(relations);
            return deletedRelations;
        }

    }
}
