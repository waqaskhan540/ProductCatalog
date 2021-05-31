using Microsoft.EntityFrameworkCore;
using Syndy.Data.Context;
using Syndy.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Syndy.Data.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly SyndyDataContext _dbContext;

        public BrandRepository(SyndyDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Brand GetByName(string brandName)
        {
            var brand = _dbContext.Brands.FirstOrDefault(b => brandName.ToLower() == b.BrandName.ToLower());
            return brand;
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            var brand = _dbContext.Brands
                            .Include(p => p.Products)
                            .Single(b => b.BrandId == brandId);

            if (brand != null)
                return brand.Products;

            return null;
        }
    }
}
