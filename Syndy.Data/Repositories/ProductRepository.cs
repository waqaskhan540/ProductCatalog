using Microsoft.EntityFrameworkCore;
using Syndy.Data.Context;
using Syndy.Data.Entities;
using Syndy.Data.Output;
using System.Collections.Generic;
using System.Linq;

namespace Syndy.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly SyndyDataContext dbContext;

        public ProductRepository(SyndyDataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product GetById(int productId)
        {          
            var product = dbContext.Products
                        .Include(x => x.Brand)
                        .SingleOrDefault(x => x.ProductId == productId);
                      
            return product;
        }

        public UserProducts GetProductsByUser(int userId)
        {
            var user = dbContext
                .Users
                .Include(x => x.UserProducts)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Brand)
                .FirstOrDefault(x => x.UserId == userId);

            if (user != null)
            {
                return new UserProducts
                {
                    UserId = user.UserId,
                    UserName = $"{user.FirstName} {user.LastName}",
                    Products = user.UserProducts.Select(x => new Product
                    {
                        ProductId = x.Product.ProductId,
                        ProductName = x.Product.ProductName,
                        Size = x.Product.Size,
                        Category = x.Product.Category,
                        Price = x.Product.Price,
                        Brand = x.Product?.Brand
                    })
                    .Where(p => !p.IsArchived)
                    .ToList()
                };
            }

            return null;

        }
    }
}
