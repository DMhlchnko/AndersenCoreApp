using AndersenCoreApp.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Interfaces.Repositories
{
    /// <summary>
    /// Category repository interface
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Returns all categories from data base
        /// </summary>
        Task<IEnumerable<Category>> GetCategoriesAsync();

        /// <summary>
        /// Returns category by it's name
        /// </summary>
        Task<IEnumerable<Category>> GetCategoriesByNamesAsync(List<string> Names);
    }
}
