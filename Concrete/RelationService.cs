using AndersenCoreApp.Abstractions;
using AndersenCoreApp.EF_Abstractions;
using AndersenCoreApp.Models;
using AndersenCoreApp.ViewDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Concrete
{
    public class RelationService : IRelationService
    {

        private IRepository<Relation> _repo;

       
        public RelationService(IRepository<Relation> repository)
        {
            _repo = repository;
        }

        public Relation GetOne(Guid id)
        {
            return _repo.GetOne(id);
        }

        public IQueryable<Relation> GetAll()
        {
            return _repo.GetAll();
        }
       
        public bool CheckPostalMask(Relation relation)
        {
            throw new NotImplementedException();
        }

        public void Create(Relation relation)
        {
            if (!CheckPostalMask(relation))
            {
                _repo.Create(relation);
            }
            else
            {
                //another logic
            }
        }

        public void Update(Relation relation)
        {
            _repo.Update(relation);
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public void DeleteRange(List<Relation> relations)
        {
            _repo.DeleteRange(relations);
        }

        public IQueryable<Relation> GetListByCategories(IQueryable<Relation> list, string orderCategory)
        {
            IQueryable<Relation> resultList = null;
            if(list.Count() > 0)
            {
                foreach (var rel in list)
                {
                    foreach (var cat in rel.Categories)
                    {
                        if (cat.Name.ToUpper() == orderCategory.ToUpper())
                        {
                            resultList = from r in list
                                   where
                                   r.Id == rel.Id
                                   select r;
                        }
                    }
                }
               
            }
            return resultList;
        }

        public IMapper ConfigureMapperForDto()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Relation, RelationDTO>()
               .ForMember("Street", opt => opt.MapFrom(c => c.RelationAddress.Street))
               .ForMember("City", opt => opt.MapFrom(c => c.RelationAddress.City))
               .ForMember("Country", opt => opt.MapFrom(c => c.RelationAddress.CountryName))
               .ForMember("PostalCode", opt => opt.MapFrom(c => c.RelationAddress.PostalCode))
               .ForMember("StreetNumber", opt => opt.MapFrom(c => c.RelationAddress.Number))).CreateMapper();

            return mapper;
        }



        public IQueryable<Relation> GetSortedListByProperties(IQueryable<Relation> list, string orderString)
        {
            
            switch (orderString)
            {
                case "Name":
                    return list.OrderBy(r => r.Name);
                case "FullName":
                    return list.OrderBy(r => r.FullName);
                case "TelephoneNumber":
                    return list.OrderBy(r => r.TelephoneNumber);
                case "Email":
                    return list.OrderBy(r => r.EmailAddress);
                case "Country":
                    return list.OrderBy(r => r.RelationAddress.Country.Name);
                case "City":
                    return list.OrderBy(r => r.RelationAddress.City);
                case "Street":
                    return list.OrderBy(r => r.RelationAddress.Street);
                case "PostalCode":
                    return list.OrderBy(r => r.RelationAddress.PostalCode);
                case "StreetNumber":
                    return list.OrderBy(r => r.RelationAddress.Number);
            }
            return list.OrderBy(r => r.Id);
    
        }
    }
    
}
