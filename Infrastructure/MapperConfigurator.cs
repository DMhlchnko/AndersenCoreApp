using AndersenCoreApp.Models.DomainModels;
using AndersenCoreApp.Models.ModelsDTO;
using AutoMapper;

namespace AndersenCoreApp.Infrastructure
{
    /// <inheritdoc />
    public class MapperConfigurator : IMapperConfigurator
    {
        /// <inheritdoc />
        public IMapper ConfigureMapperForViewModel()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Relation, RelationDTO>()
               .ForMember("Street", opt => opt.MapFrom(c => c.RelationAddress.Street))
               .ForMember("City", opt => opt.MapFrom(c => c.RelationAddress.City))
               .ForMember("Country", opt => opt.MapFrom(c => c.RelationAddress.Country.Name))
               .ForMember("PostalCode", opt => opt.MapFrom(c => c.RelationAddress.PostalCode))
               .ForMember("EMail", opt => opt.MapFrom(c => c.EmailAddress))
               .ForMember("StreetNumber", opt => opt.MapFrom(c => c.RelationAddress.Number))).CreateMapper();

            return mapper;
        }

        /// <inheritdoc />
        public IMapper ConfigureMapperForRelation()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RelationDTO, Relation>()
            .ForPath(r => r.RelationAddress.Street, opt => opt.MapFrom(m => m.Street))
            .ForPath(r => r.RelationAddress.City, opt => opt.MapFrom(m => m.City))
            .ForPath(r => r.RelationAddress.Country.Name, opt => opt.MapFrom(m => m.Country))
            .ForPath(r => r.RelationAddress.PostalCode, opt => opt.MapFrom(m => m.PostalCode))
            .ForMember(r => r.EmailAddress, opt => opt.MapFrom(m => m.EMail))
            .ForPath(r => r.RelationAddress.Number, opt => opt.MapFrom(m => m.StreetNumber))).CreateMapper();

            return mapper;
        }

    }
}
