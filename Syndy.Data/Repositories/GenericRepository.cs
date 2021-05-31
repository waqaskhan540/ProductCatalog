using Microsoft.EntityFrameworkCore;
using Syndy.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syndy.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        
        private readonly DbSet<T> _dbSet;
        private readonly SyndyDataContext _dbContext;

        public GenericRepository(SyndyDataContext dbContext)
        {                        
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
       
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetAsQueryable()
        {
            return _dbSet.AsQueryable<T>();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
