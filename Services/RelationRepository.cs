using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AndersenCoreApp.Infrastructure.RelationFilter;

namespace AndersenCoreApp.Services
{
    public class RelationRepository : IRelationRepository
    {
        private RelationContext db = new RelationContext();

        public async Task<bool> HasAnyAsync(Guid id)
        {
            return await db.Relations.AnyAsync(r => r.Id == id);
        }

        public void Delete(params Guid[] identificators)
        {
            foreach (var id in identificators)
            {
                var entityToDelete = db.Relations.FirstOrDefault(r => r.Id == id);
                if (entityToDelete != null)
                {
                    entityToDelete.IsDisabled = true;
                    db.Entry(entityToDelete).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public void Create(Relation relation)
        {
            if (!db.Relations.Any(r => r.Id == relation.Id))
            {
                db.Relations.Add(relation);
                db.SaveChanges();
            }
        }

        public async Task<IReadOnlyCollection<Relation>> GetAllAsync(RelationFilter filter)
        {
            var relations = await GetSortedAndFilteredRelations(filter);

            return await relations.ToListAsync();
        }

        public async Task<Relation> GetOneAsync(Guid id)
        {
            return await db.Relations.FirstOrDefaultAsync(r => r.Id == id);
        }

        public void Update(Relation entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        private async Task<IQueryable<Relation>> GetSortedAndFilteredRelations(RelationFilter filter)
        {
            var orderBy = filter.Order;
            var orderProperty = filter.sortByProperty;
            //doesn't work with string.Equals(r.Name,filter.filterByCategoryName,StringComparison.InvariantCultureIgnoreCase)
            var category = await db.Categories.FirstOrDefaultAsync(c => c.Name.ToUpper() == filter.filterByCategoryName.ToUpper());
            var query = db.Relations.Where(r => r.RelationCategories.Any(rc => rc.CategoryId == category.Id));
            return (orderProperty.ToUpper()) switch
            {
                "NAME" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.Name) : query.OrderByDescending(r => r.Name),
                "FULLNAME" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.FullName) : query.OrderByDescending(r => r.FullName),
                "TELEPHONENUMBER" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.TelephoneNumber) : query.OrderByDescending(r => r.TelephoneNumber),
                "EMAIL" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.EmailAddress) : query.OrderByDescending(r => r.EmailAddress),
                "COUNTRY" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.RelationAddress.Country.Name) : query.OrderByDescending(r => r.RelationAddress.Country.Name),
                "CITY" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.RelationAddress.City) : query.OrderByDescending(r => r.RelationAddress.City),
                "STREET" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.RelationAddress.Street) : query.OrderByDescending(r => r.RelationAddress.Street),
                "POSTALCODE" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.RelationAddress.PostalCode) : query.OrderByDescending(r => r.RelationAddress.PostalCode),
                "STREETNUMBER" => orderBy == OrderBy.Ascending ? query.OrderBy(r => r.RelationAddress.Number) : query.OrderByDescending(r => r.RelationAddress.Number),
                _ => query.OrderBy(r => r.Id),
            };
        }

    }
}
