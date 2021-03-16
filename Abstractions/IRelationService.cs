using AndersenCoreApp.EF_Abstractions;
using AndersenCoreApp.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Abstractions
{
    public interface IRelationService 
    {
       
        IQueryable<Relation> GetSortedListByProperties(IQueryable<Relation> list, string orderString);

        IQueryable<Relation> GetListByCategories(IQueryable<Relation> list, string orderCategory);

        bool CheckPostalMask(Relation relation);

        void Create(Relation relation);

        IMapper ConfigureMapperForDto();

        Relation GetOne(Guid id);

        IQueryable<Relation> GetAll();

        void Update(Relation relation);

        void Delete(Guid id);

        void DeleteRange(List<Relation> relations);

    }
}
