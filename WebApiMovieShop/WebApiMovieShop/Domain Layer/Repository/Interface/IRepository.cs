using System.Collections.Generic;

namespace WebApiMovieShop
{
    internal interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T item);
        void Remove(T movie);
        bool Update(T item);
    }
}