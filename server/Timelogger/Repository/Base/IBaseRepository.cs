using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Timelogger.Repository
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        ICollection<T> GetByCondition(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        ICollection<T> GetAll(params Expression<Func<T, object>>[] includes);
        void Update(T entity);
        void Delete(T entity);
    }
}
