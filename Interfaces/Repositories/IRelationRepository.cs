using AndersenCoreApp.Models.DomainModels;
using System;
using System.Linq;

namespace AndersenCoreApp.Interfaces.Repositories
{
    public interface IRelationRepository
    {
        bool Any(Guid id);
        Relation GetOne(Guid id);
        IQueryable<Relation> GetAll();
        void Update(Relation entity);
        void Create(Relation entity);
        void Delete(params Guid[] id);
    }
}
