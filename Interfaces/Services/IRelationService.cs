using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Models.DomainModels;
using AndersenCoreApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndersenCoreApp.Interfaces.Services
{
    public interface IRelationService : IMapperConfigurator
    {
        List<RelationViewModel> GetSortedAndFilteredRelations(IQueryable<Relation> list, string categoryName, string orderProperties);
        bool CheckPostalMask(Relation relation);
        void Create(RelationViewModel relation);
        RelationViewModel GetOne(Guid id);
        IQueryable<Relation> GetAll();
        bool ContainsRelation(Guid id);
        void Update(RelationViewModel relation);
        void Delete(params Guid[] identificators);
    }
}
