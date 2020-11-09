using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Timelogger.Repository
{
    public class BaseRepotitory<T> : IBaseRepository<T> where T : class
    {
        protected ApiContext ApiContext { get; set; }

        public BaseRepotitory(ApiContext apiContext)
        {
            ApiContext = apiContext ?? throw new ArgumentNullException(nameof(apiContext));
        }

        public void Create(T entity)
        {
            ApiContext.Set<T>().Add(entity);
        }

        public ICollection<T> GetByCondition(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = ApiContext.Set<T>().Where(expression).AsNoTracking();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public ICollection<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = ApiContext.Set<T>().AsNoTracking();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public void Update(T entity)
        {
            ApiContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            ApiContext.Set<T>().Remove(entity);
        }
    }
}
