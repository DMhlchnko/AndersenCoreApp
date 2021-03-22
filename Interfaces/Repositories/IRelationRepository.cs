using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Interfaces.Repositories
{
    public interface IRelationRepository
    {
        Task<bool> HasAnyAsync(Guid id);

        Task<Relation> GetOneAsync(Guid id);

        Task<IReadOnlyCollection<Relation>> GetAllAsync(RelationFilter filter);

        void Update(Relation entity);

        void Create(Relation entity);

        void Delete(params Guid[] id);
    }
}
