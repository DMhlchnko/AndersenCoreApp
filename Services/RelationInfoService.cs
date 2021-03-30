using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Services
{
    public class RelationInfoService : IRelationInfoService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public RelationInfoService(ICategoryRepository categoryRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDTO;
        }

        public async Task<IEnumerable<CountryDTO>> GetCoutriesAsync()
        {
            var countries = await _countryRepository.GetAllAsync();
            var countriesDTO = _mapper.Map<IEnumerable<CountryDTO>>(countries);
            return countriesDTO;
        }
    }
}
