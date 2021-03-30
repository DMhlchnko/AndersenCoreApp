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
    }
}
