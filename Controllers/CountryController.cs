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
    public class CountryController : ControllerBase
    {
        private IRelationService _relationService;

        public CountryController(IRelationService service)
        {
            _relationService = service;
        }

        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            var countries = await _relationService.GetCoutryList();
            return countries;
        }
    }
}
