using AndersenCoreApp.Models.DomainModels;
using System;
using System.Linq;

namespace AndersenCoreApp.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        IQueryable<Country> GetAll();
        Country GetOne(string name);
        bool Any(Guid id);
    }
}
