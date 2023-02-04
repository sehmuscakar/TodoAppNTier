using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interafces
{
    public interface IRepository<T> where T:BaseEntity
    {
        //task olanlar asekronik olacak yani 
        Task<List<T>> GetAll();
        Task<T> Find(object id);

        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task Create (T entity);
        void Update (T entity,T unchanged);
        void Remove (T entity);

        IQueryable<T> GetQuery();
      
    }
}
