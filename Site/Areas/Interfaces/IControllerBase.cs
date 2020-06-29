using System.Collections.Generic;

namespace Site.Areas.Interfaces
{
    public interface IControllerBase<T> where T : class
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
        void Dispose();
    }
}