using Syndy.Data.Entities;
using Syndy.Data.Output;
using System.Collections.Generic;

namespace Syndy.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
       UserProducts GetProductsByUser(int userId);
       Product GetById(int productId);
    }
}
