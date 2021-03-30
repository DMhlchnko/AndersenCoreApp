using AndersenCoreApp.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Interfaces.Services
{
    public interface IRelationInfoService
    {
        /// <summary>
        /// Returns a list of all Countries
        /// </summary>
        Task<IEnumerable<CountryDTO>> GetCoutriesAsync();

        /// <summary>
        /// Returns a list of Categories
        /// </summary>
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    }
}
