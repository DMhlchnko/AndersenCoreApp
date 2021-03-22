using AutoMapper;

namespace AndersenCoreApp.Infrastructure
{
    /// <summary>
    /// Mapper configurator interface.
    /// </summary>
    public interface IMapperConfigurator
    {
        /// <summary>
        /// Configures mapper for view model.
        /// </summary>
        IMapper ConfigureMapperForViewModel();

        /// <summary>
        /// Configure mapper for relation.
        /// </summary>
        IMapper ConfigureMapperForRelation();
    }
}
