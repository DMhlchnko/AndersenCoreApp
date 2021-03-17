using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AndersenCoreApp.Services
{
    public class RelationRepository : IRelationRepository
    {
        private RelationContext db = new RelationContext("Server=(local)\\SQLEXPRESS;Database=test;Trusted_Connection=True;");

        public bool Any(Guid id)
        {
            return db.Relations.Any(r => r.Id == id);
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

        public IQueryable<Relation> GetAll()
        {
            return db.Relations.AsQueryable();
        }

        public Relation GetOne(Guid id)
        {
            return db.Relations.FirstOrDefault(r => r.Id == id);
        }

        public void Update(Relation entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
