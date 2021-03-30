using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Infrastructure
{
    /// <summary>
    /// Country profile class for automapper
    /// </summary>
    public class CountryMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor that configures automapper
        /// </summary>
        public CountryMapperProfile()
        {
            CreateMap<Country, CountryDTO>();
        }
    }
}
