using Syndy.Data.Entities;
using System.Collections.Generic;

namespace Syndy.Data.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        List<Product> GetProductsByBrand(int brandId);
        Brand GetByName(string brandName);
    }
}
