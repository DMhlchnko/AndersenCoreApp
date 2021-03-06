using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Services
{
    /// <inheritdoc />
    public class RelationRepository : IRelationRepository
    {
    private readonly RelationContext _db;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RelationRepository(RelationContext db)
        {
            _db = db;
        }

        /// <inheritdoc />
        public async Task<bool> HasAnyAsync(Guid id)
        {
            return await _db.Relations.AnyAsync(r => r.Id == id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Relation>> DeleteAsync(params Guid[] identificators)
        {
            List<Relation> relationsToDelete = new List<Relation>();
            foreach (var id in identificators)
            {
                var relationToDelete = await _db.Relations.FirstOrDefaultAsync(r => r.Id == id);
                relationsToDelete.Add(relationToDelete);
            }
            foreach (var relation in relationsToDelete)
            {
                if(!relation.IsDisabled)
                {
                    relation.IsDisabled = true;
                    _db.Entry(relation).State = EntityState.Modified;
                }
            }
            await _db.SaveChangesAsync();

            return relationsToDelete;
        }

        /// <inheritdoc />
        public async Task<Relation> CreateAsync(Relation relation)
        {
            await _db.Relations.AddAsync(relation);
            await _db.SaveChangesAsync();
            
            return relation;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<Relation>> GetAllAsync(RelationFilter filter)
        {
            var queryRelations = await GetSortedAndFilteredRelations(filter);
            var relations = await queryRelations.Where(r => r.IsDisabled == false).ToListAsync();
            if(relations != null)
            {
                foreach (var relation in relations)
                {
                    var relationCategories = await _db.RelationCategories.Where(c => c.RelationId == relation.Id).ToListAsync();
                    foreach (var relationCategory in relationCategories)
                    {
                        var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == relationCategory.CategoryId);
                        if(category != null)
                        {
                            relation.Categories.Add(category?.Name);
                        }
                    }
                }
            }
            

            return relations;
        }

        /// <inheritdoc />
        public async Task<Relation> GetOneAsync(Guid id)
        {
            var relation = await _db.Relations.FirstOrDefaultAsync(r => r.Id == id && r.IsDisabled == false);

            return relation; 
        }

        /// <inheritdoc />
        public async Task<Relation> UpdateAsync(Relation entity)
        {
            var categories = _db.RelationCategories.Where(rc => rc.RelationId == entity.Id);
            _db.RelationCategories.RemoveRange(categories);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            var relationAfterUpdate = await _db.Relations.FirstOrDefaultAsync(r => r.Id == entity.Id);

            return relationAfterUpdate;
        }

        /// <summary>
        /// Method for filtering and sorting Relations
        /// </summary>
        private async Task<IQueryable<Relation>> GetSortedAndFilteredRelations(RelationFilter filter)
        {
            var orderBy = filter.Order;
            var sortByProperty = filter.SortByProperty;
            var filterCategory = filter.FilterByCategoryName;
            IQueryable<Relation> query = _db.Relations.AsQueryable();
            if (!string.IsNullOrEmpty(filterCategory))
            {
                var category = await _db.Categories.FirstOrDefaultAsync(c => c.Name.ToUpper().Equals
                (filterCategory.ToUpper()));
                query = _db.Relations.Where(r => r.RelationCategories.Any(rc => rc.CategoryId == category.Id));
            }
            if (string.IsNullOrEmpty(sortByProperty))
            {
                return query;
            }

            return (sortByProperty.ToUpper()) switch
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
                _ => query
            };
        }
    }
}
