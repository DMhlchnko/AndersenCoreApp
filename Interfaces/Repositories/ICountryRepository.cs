using AndersenCoreApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Interfaces.Repositories
{
    /// <summary>
    /// Country repository inteface
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Return all countries from table tblCountry
        /// </summary>
        Task<IReadOnlyCollection<Country>> GetAllAsync();

        /// <summary>
        /// Returns one Country by name
        /// </summary>
        Task<Country> GetOneAsync(string name);

        /// <summary>
        /// Checks an existance of the Country in the table tblCountry
        /// </summary>
        Task<bool> HasAnyAsync(Guid id);
    }
}
