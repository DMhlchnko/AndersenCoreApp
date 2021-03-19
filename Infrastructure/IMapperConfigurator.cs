using AutoMapper;

namespace AndersenCoreApp.Infrastructure
{
    public interface IMapperConfigurator
    {
        IMapper ConfigureMapperForViewModel();
        IMapper ConfigureMapperForRelation();

    }
}
