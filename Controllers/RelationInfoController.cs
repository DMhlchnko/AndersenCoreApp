using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RelationInfoController : ControllerBase
    {
        private IRelationInfoService _relationInfoService;

        public RelationInfoController(IRelationInfoService service)
        {
            _relationInfoService = service;
        }
        [HttpGet]
        public async Task<IEnumerable<CountryDTO>> GetCountriesAsync()
        {
            var countries = await _relationInfoService.GetCoutriesAsync();
            return countries;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _relationInfoService.GetCategoriesAsync();

            return categories;
        }
    }
}
