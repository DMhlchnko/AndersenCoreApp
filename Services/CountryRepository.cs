using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndersenCoreApp.Services
{
    /// <inheritdoc />
    public class CountryRepository : ICountryRepository 
    { 

        private readonly RelationContext _db;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CountryRepository(RelationContext db)
        {
            _db = db;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<Country>> GetAllAsync()
        {
            var countries = await _db.Countries.ToListAsync();
            return countries;
        }

        /// <inheritdoc />
        public async Task<Country> GetOneAsync(string name)
        {
            var country = await _db.Countries.FirstOrDefaultAsync(
                c => string.Equals(c.Name,name,StringComparison.InvariantCultureIgnoreCase) == true);

            return country;
        }

        /// <inheritdoc />
        public async Task<bool> HasAnyAsync(Guid id)
        {
            return await _db.Countries.AnyAsync(c => c.Id == id);
        }
    }
}
