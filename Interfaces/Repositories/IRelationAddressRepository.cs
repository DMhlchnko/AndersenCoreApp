using AndersenCoreApp.Models.Domain;
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
        Task<RelationAddress> CreateAsync(string city, string street, int streetNumber, string postalCode, Guid countryId);

        /// <summary>
        /// Updates relation address 
        /// </summary>
        /// <returns>Updated relation address</returns>
        Task<RelationAddress> UpdateAsync(RelationAddress relationAddress);

        /// <summary>
        /// Returns relation address by it's id
        /// </summary>
        Task<RelationAddress> FindAsync(Guid id);
    }
}
