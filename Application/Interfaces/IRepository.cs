using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<int> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
