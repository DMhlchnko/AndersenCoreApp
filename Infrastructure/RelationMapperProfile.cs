using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Infrastructure
{
    public class RelationMapperProfile : Profile
    {
        public RelationMapperProfile()
        {
            CreateMap<Relation, RelationDTO>()
               .ForMember("Street", opt => opt.MapFrom(c => c.RelationAddress.Street))
               .ForMember("City", opt => opt.MapFrom(c => c.RelationAddress.City))
               .ForMember("Country", opt => opt.MapFrom(c => c.RelationAddress.Country.Name))
               .ForMember("PostalCode", opt => opt.MapFrom(c => c.RelationAddress.PostalCode))
               .ForMember("EMail", opt => opt.MapFrom(c => c.EmailAddress))
               .ForMember("StreetNumber", opt => opt.MapFrom(c => c.RelationAddress.Number)).ReverseMap();
        }
    }
}
