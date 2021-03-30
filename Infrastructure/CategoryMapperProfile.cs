using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
using AutoMapper;

namespace AndersenCoreApp.Infrastructure
{
    /// <summary>
    /// Category profile class for automapper
    /// </summary>
    public class CategoryMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor that configures automapper
        /// </summary>
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}
