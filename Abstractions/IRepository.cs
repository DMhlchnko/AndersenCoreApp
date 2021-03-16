using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AndersenCoreApp.EF_Abstractions
{
    public interface IRepository<T> where T: class 
    {
        T GetOne(Guid id);
        IQueryable<T> GetAll();
        void Update(T entity);
        void Create(T entity);
        void Delete(Guid id);
        void DeleteRange(List<T> entities);
    }
}
