using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RelationContext _db;

        public CategoryRepository(RelationContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _db.Categories.ToListAsync();
            return categories;
        }
    }
}
