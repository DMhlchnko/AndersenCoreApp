using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Interfaces.Repositories
{
    /// <summary>
    /// Relation repository interface
    /// </summary>
    public interface IRelationRepository
    {
        /// <summary>
        /// An asynchronous method which cheks an existance of Relation
        /// </summary>
        /// <param name="id">Relation id</param>
        Task<bool> HasAnyAsync(Guid id);

        /// <summary>
        /// An asynchronous method which returns Relation by its id
        /// </summary>
        /// <param name="id">Relation id</param>
        Task<Relation> GetOneAsync(Guid id);

        /// <summary>
        /// An asynchronous method which returns 
        /// IReadOnlyCollection of Relations using 
        /// special filter to sort, filter and order collection
        /// </summary>
        Task<IReadOnlyCollection<Relation>> GetAllAsync(RelationFilter filter);

        /// <summary>
        /// Updates choosed Relation
        /// </summary>
        Task<Relation> UpdateAsync(Relation entity);

        /// <summary>
        /// Creates a new Relation
        /// </summary>
        Task<Relation> CreateAsync(Relation entity);

        /// <summary>
        /// Deletes choosed Relations
        /// </summary>
        Task<IEnumerable<Relation>> DeleteAsync(params Guid[] identificators);
    }
}
