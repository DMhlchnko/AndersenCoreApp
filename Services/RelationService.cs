using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.DomainModels;
using AndersenCoreApp.Models.ModelsDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Services
{
    public class RelationService : IRelationService
    {
        private readonly IRelationRepository _relationRepo;
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _viewModelMapper;
        private readonly IMapper _relationMapper;

        public RelationService(IRelationRepository relations, ICountryRepository countries, IMapperConfigurator configurator)
        {
            _relationRepo = relations;
            _countryRepo = countries;
            _viewModelMapper = configurator.ConfigureMapperForViewModel();
            _relationMapper = configurator.ConfigureMapperForRelation();
        }

        public async Task<bool> CheckRelationExistence(Guid relationId)
        {
            var result = await _relationRepo.HasAnyAsync(relationId);
            return result;
        }

        public async Task<RelationDTO> GetOneAsync(Guid id)
        {
            var relation = await _relationRepo.GetOneAsync(id);
            var relationsViewModel = _viewModelMapper.Map<Relation, RelationDTO>(relation);
            return relationsViewModel;
        }

        public async Task<IEnumerable<RelationDTO>> GetRelationsAsync(RelationFilter filter)
        {
            var relations = await _relationRepo.GetAllAsync(filter);
            var relationViewModels = _viewModelMapper.Map<IReadOnlyCollection<Relation>, IEnumerable<RelationDTO>>(relations);
            return relationViewModels;
        }

        //TODO write an algorithm for checking postal mask
        public bool CheckPostalMask(string postalCodeFormat, string postalCode)
        {
            throw new NotImplementedException();
        }

        public void Create(RelationDTO relation)
        {
            if (relation != null)
            {
                var postalCodeFormat = _countryRepo.GetOne(relation.Country).PostalCodeFormat;
                var postalCode = relation?.PostalCode;
                if (CheckPostalMask(postalCodeFormat, postalCode))
                {
                    relation.PostalCode = ApplyPostalCodeMask(postalCode, postalCodeFormat);
                }
                var relationToCreate = _relationMapper.Map<RelationDTO, Relation>(relation);
                _relationRepo.Create(relationToCreate);
            }
        }

        public void Update(RelationDTO relation)
        {
            var postalCodeFormat = _countryRepo.GetOne(relation.Country).PostalCodeFormat;
            var postalCode = relation?.PostalCode;
            if (CheckPostalMask(postalCodeFormat, postalCode))
            {
                relation.PostalCode = ApplyPostalCodeMask(postalCode, postalCodeFormat);
            }
            var relationToUpdate = _relationMapper.Map<RelationDTO, Relation>(relation);
            _relationRepo.Update(relationToUpdate);
        }

        public void Delete(params Guid[] identificators)
        {
            _relationRepo.Delete(identificators);
        }

        //TODO write an algorithm for applying postal mask
        public string ApplyPostalCodeMask(string postalCode, string postalCodeFormat)
        {
            return postalCode;
        }
    }
}
