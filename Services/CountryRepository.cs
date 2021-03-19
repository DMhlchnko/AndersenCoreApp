using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.DomainModels;
using System;
using System.Linq;

namespace AndersenCoreApp.Services
{
    public class CountryRepository : ICountryRepository
    {
        private RelationContext db = new RelationContext();

        public IQueryable<Country> GetAll()
        {
            return db.Countries.AsQueryable();
        }

        public Country GetOne(string name)
        {
            return db.Countries.FirstOrDefault(c => c.Name == name);
        }

        public bool Any(Guid id)
        {
            return db.Countries.Any(c => c.Id == id);
        }
    }
}
