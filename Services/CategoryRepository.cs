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
        /// <summary>
        /// Default  category repository constructor
        /// </summary>
        public CategoryRepository(RelationContext context)
        {
            _db = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _db.Categories.ToListAsync();
            return categories;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Category>> GetCategoriesByNamesAsync(List<string> Names)
        {
            var categories = new List<Category>();
            foreach(var name in Names)
            {
                var category = await _db.Categories.FirstOrDefaultAsync(c => c.Name == name);
                if(category != null)
                {
                    categories.Add(category);
                }
            }

            return categories; 
        }
    }
}
