using Syndy.Data.Repositories;
using Syndy.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndy.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public List<ProductDto> GetProductsByBrand(int brandId)
        {
            var products = _brandRepository.GetProductsByBrand(brandId);
            if(products != null)
            {
                return products.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Size = p.Size,
                    Color = p.Color,
                    Category = p.Category,
                    Brand = p.Brand?.BrandName,
                    Price = p.Price
                }).ToList();
            }

            return new List<ProductDto>();
        }
    }
}
