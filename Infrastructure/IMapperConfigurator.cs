using AutoMapper;

namespace AndersenCoreApp.Infrastructure
{
    public interface IMapperConfigurator
    {
        IMapper ConfigureMapperForDto();
        IMapper ConfigureMapperForViewModel();
    }
}
