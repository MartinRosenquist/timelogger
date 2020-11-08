using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Timelogger.Repository
{
    class BaseRepotitory<T> : IBaseRepository<T> where T : class
    {
        private ApiContext _apiContext;
        private DbSet<T> _table;

        public BaseRepotitory(ApiContext apiContext)
        {
            _apiContext = apiContext;
            _table = _apiContext.Set<T>();
        }

        public void Delete(int id)
        {
            T exsist = _table.Find(id);
            _table.Remove(exsist);
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Save()
        {
            _apiContext.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _apiContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
