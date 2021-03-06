using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
using AutoMapper;

namespace AndersenCoreApp.Infrastructure
{
    /// <summary>
    /// Relation profile class for automapper
    /// </summary>
    public class RelationMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor that configures automapper
        /// </summary>
        public RelationMapperProfile()
        {
            CreateMap<Relation, RelationDTO>()
               .ForMember("Street", opt => opt.MapFrom(c => c.RelationAddress.Street))
               .ForMember("City", opt => opt.MapFrom(c => c.RelationAddress.City))
               .ForMember("Country", opt => opt.MapFrom(c => c.RelationAddress.Country.Name))
               .ForMember("PostalCode", opt => opt.MapFrom(c => c.RelationAddress.PostalCode))
               .ForMember("Email", opt => opt.MapFrom(c => c.EmailAddress))
               .ForMember("StreetNumber", opt => opt.MapFrom(c => c.RelationAddress.Number))
               .ForMember("Id",opt => opt.MapFrom(c => c.Id)).ReverseMap();
        }
    }
}
