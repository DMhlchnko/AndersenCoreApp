using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Interfaces.Services
{
    /// <summary>
    /// Relation Service interface
    /// </summary>
    public interface IRelationService
    {
        /// <summary>
        /// Creates new Relation
        /// </summary>
        /// /// <returns>Created Relation</returns>
        Task<RelationDTO> CreateAsync(RelationDTO relation);

        /// <summary>
        /// Returns Relation by guid
        /// </summary>
        Task<RelationDTO> GetOneAsync(Guid id);

        /// <summary>
        /// Returns all Relations from te database
        /// </summary>
        Task<IEnumerable<RelationDTO>> GetRelationsAsync(RelationFilter filter);

        /// <summary>
        /// Checks if any Relation exists in database
        /// </summary>
        Task<bool> CheckRelationExistenceAsync(Guid relationId);

        /// <summary>
        /// Updates the Relation
        /// </summary>
        /// /// <returns>Updated Relation</returns>
        Task<RelationDTO> UpdateAsync(RelationDTO relation);

        /// <summary>
        /// Deletes the Relations by guid
        /// </summary>
        /// <returns>A list of deleted Relations</returns>
        Task<IEnumerable<RelationDTO>> DeleteAsync(params Guid[] identificators);
    }
}
