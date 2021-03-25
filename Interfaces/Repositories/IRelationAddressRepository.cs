using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Interfaces.Repositories
{
    /// <summary>
    /// RelationAddress repository
    /// </summary>
    public interface IRelationAddressRepository
    {
        /// <summary>
        /// Creates relation address object
        /// </summary>
        /// <returns>Created relation address</returns>
        Task<RelationAddress> CreateAsync(RelationDTO relation, Guid countryId);

        /// <summary>
        /// Updates relation address 
        /// </summary>
        /// <returns>Updated relation address</returns>
        Task<RelationAddress> UpdateAsync(RelationDTO relation, Guid relationAddressId);

        /// <summary>
        /// Returns relation address by it's id
        /// </summary>
        Task<RelationAddress> FindAsync(Guid id);
    }
}
