using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syndy.Data.Repositories
{
    public interface IRepository<T> where T:class
    {

        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> GetAsQueryable();
        Task<IEnumerable<T>> GetAll();
    }
}
