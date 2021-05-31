using Syndy.Services.DTOs;
using Syndy.Services.Inputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syndy.Services.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProducts();
        ProductDto GetProductById(int id);

        UserProductsDto GetAllProductsByUser(int userId);

        ProductDto ArchiveProduct(int productId,ArchiveProductModel model);
        ProductDto CreateProduct(CreateProductModel product);

        ProductDto UpdateProduct(int productId, UpdateProductModel product);
    }
}
