using DataAccess.Contexts;
using DataAccess.Interafces;
using DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitofWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _todoContext;

        public Uow(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_todoContext);
        }

        public async  Task SaveChanges()
        {
            await _todoContext.SaveChangesAsync();
        }
    }
}
