using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Interfaces.Services
{
    public interface IRelationService
    {

        bool CheckPostalMask(string postalCode, string postalCodeFormat);
        string ApplyPostalCodeMask(string postalCode, string postalCodeFormat);
        void Create(RelationDTO relation);
        Task<RelationDTO> GetOneAsync(Guid id);
        Task<IEnumerable<RelationDTO>> GetRelationsAsync(RelationFilter filter);
        Task<bool> CheckRelationExistence(Guid relationId);
        void Update(RelationDTO relation);
        void Delete(params Guid[] identificators);
    }
}
