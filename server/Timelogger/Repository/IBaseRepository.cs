using System.Collections.Generic;

namespace Timelogger.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }
}
