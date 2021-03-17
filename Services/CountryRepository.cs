using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.DomainModels;
using System;
using System.Linq;

namespace AndersenCoreApp.Services
{
    public class CountryRepository : ICountryRepository
    {
        private RelationContext db = new RelationContext("Server=(local)\\SQLEXPRESS;Database=test;Trusted_Connection=True;");

        public IQueryable<Country> GetAll()
        {
            return db.Countries.AsQueryable();
        }

        public bool Any(Guid id)
        {
            return db.Countries.Any(c => c.Id == id);
        }
    }
}
