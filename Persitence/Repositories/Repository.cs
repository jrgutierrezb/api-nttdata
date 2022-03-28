using Application.Interfaces;
using Persitence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persitence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();

        }

        public async Task AddRange(System.Collections.Generic.IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<System.Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(System.Collections.Generic.IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
