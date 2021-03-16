
using AndersenCoreApp.EF_Abstractions;
using AndersenCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AndersenCoreApp.Repositories
{
    public class RelationRepository : IRepository<Relation>
    {
        private RelationContext db = new RelationContext("Server=(local)\\SQLEXPRESS;Database=test;Trusted_Connection=True;");

       
        public void Delete(Guid id)
        {
            var entityToDelete = db.Relations.FirstOrDefault(r => r.Id == id);
            if (entityToDelete != null)
            {
                entityToDelete.IsDisabled = true;
                db.Entry(entityToDelete).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteRange(List<Relation> entities)
        {
            if(entities != null)
            {
                foreach (var entity in entities)
                {
                    entity.IsDisabled = true;
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public void Create(Relation relation)
        {
            if(!db.Relations.Any(r => r.Id == relation.Id))
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
