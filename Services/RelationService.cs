using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.DomainModels;
using AndersenCoreApp.Models.ModelsDTO;
using AndersenCoreApp.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndersenCoreApp.Services
{
    public class RelationService : IRelationService
    {
        private IRelationRepository relationRepo;
        private ICountryRepository countryRepo;
        private IMapper ViewModelMapper;

        public RelationService(IRelationRepository relations, ICountryRepository countries)
        {
            relationRepo = relations;
            countryRepo = countries;
            ViewModelMapper = ConfigureMapperForViewModel();
        }

        public bool ContainsRelation(Guid id)
        {
            return relationRepo.Any(id);
        }

        public RelationViewModel GetOne(Guid id)
        {
            var relation = relationRepo.GetOne(id);
            return ViewModelMapper.Map<Relation, RelationViewModel>(relation);
        }

        public IQueryable<Relation> GetAll()
        {
            return relationRepo.GetAll();
        }

        //TODO write an algorithm for checking postal mask
        public bool CheckPostalMask(Relation relation)
        {
            throw new NotImplementedException();
        }

        public void Create(RelationViewModel relation)
        {
            if (relation != null)
            {
                var relationToCreate = CreateRelationFromRelationViewModel(relation);
                relationRepo.Create(relationToCreate);
            }
        }

        public void Update(RelationViewModel relation)
        {
            if (relation != null)
            {
                var relationToUpdate = CreateRelationFromRelationViewModel(relation);
                relationRepo.Update(relationToUpdate);
            }
        }

        public void Delete(params Guid[] identificators)
        {
            relationRepo.Delete(identificators);
        }

        public List<RelationViewModel> GetSortedAndFilteredRelations(IQueryable<Relation> list, string categoryName, string orderProperties)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                //Filters collection of Relations by choosed category
                list = GetRelationsByCategories(list, orderProperties);
            }

            if (!string.IsNullOrEmpty(orderProperties))
            {
                //ordering collection by choosed properties
                list = GetSortedRelationsByProperties(list, orderProperties);
            }

            return ViewModelMapper.Map<List<Relation>, List<RelationViewModel>>(list.ToList());
        }

        //TODO write an algorithm for applying postal mask
        public string ApplyPostalCodeMask(string postalCode, string postalCodeFormat)
        {
            return postalCode;
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

        public IMapper ConfigureMapperForViewModel()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Relation, RelationViewModel>()
               .ForMember("Street", opt => opt.MapFrom(c => c.RelationAddress.Street))
               .ForMember("City", opt => opt.MapFrom(c => c.RelationAddress.City))
               .ForMember("Country", opt => opt.MapFrom(c => c.RelationAddress.CountryName))
               .ForMember("PostalCode", opt => opt.MapFrom(c => c.RelationAddress.PostalCode))
               .ForMember("StreetNumber", opt => opt.MapFrom(c => c.RelationAddress.Number))).CreateMapper();

            return mapper;
        }

        public IQueryable<Relation> GetSortedRelationsByProperties(IQueryable<Relation> list, string orderString)
        {
            switch (orderString.ToUpper())
            {
                case "NAME":
                    return list.OrderBy(r => r.Name);
                case "FULLNAME":
                    return list.OrderBy(r => r.FullName);
                case "TELEPHONENUMBER":
                    return list.OrderBy(r => r.TelephoneNumber);
                case "EMAIL":
                    return list.OrderBy(r => r.EmailAddress);
                case "COUNTRY":
                    return list.OrderBy(r => r.RelationAddress.Country.Name);
                case "CITY":
                    return list.OrderBy(r => r.RelationAddress.City);
                case "STREET":
                    return list.OrderBy(r => r.RelationAddress.Street);
                case "POSTALCODE":
                    return list.OrderBy(r => r.RelationAddress.PostalCode);
                case "STREETNUMBER":
                    return list.OrderBy(r => r.RelationAddress.Number);
            }
            return list.OrderBy(r => r.Id);
        }

        public IQueryable<Relation> GetRelationsByCategories(IQueryable<Relation> list, string filterCategory)
        {
            list = list.Where(c => c.Categories.Any(n => n.Name.ToUpper() == filterCategory.ToUpper()));
            return list;
        }

        private Relation CreateRelationFromRelationViewModel(RelationViewModel model)
        {
            var country = countryRepo.GetAll().FirstOrDefault(c => c.Name == model.Country);
            Relation relationToCreate = new Relation
            {
                Id = model.Id,
                Name = model.Name,
                FullName = model.FullName,
                EmailAddress = model.EMail,
                RelationAddress = new RelationAddress
                {
                    RelationId = model.Id,
                    City = model.City,
                    Street = model.Street,
                    Number = model.StreetNumber,
                    Country = country,
                    PostalCode = model.PostalCode
                }
            };

            if (CheckPostalMask(relationToCreate))
            {
                relationToCreate.RelationAddress.PostalCode = ApplyPostalCodeMask(model.PostalCode,
                    relationToCreate.RelationAddress.Country.PostalCodeFormat);
            }

            return relationToCreate;
        }
    }
}
