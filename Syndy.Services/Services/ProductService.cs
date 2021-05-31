using Syndy.Data.Entities;
using Syndy.Data.Repositories;
using Syndy.Services.DTOs;
using Syndy.Services.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndy.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductService(IProductRepository productRepository, IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        public ProductDto ArchiveProduct(int productId, ArchiveProductModel model)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new Exception("Product not found.");

            product.IsArchived = model.Archive;
            _productRepository.Update(product);

            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName
            };

        }

        public ProductDto CreateProduct(CreateProductModel product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new Exception("Product name cannot be empty.");

            if (string.IsNullOrWhiteSpace(product.Brand))
                throw new Exception("Brand name cannot be emtpy.");

            if (product.Price == 0F || product.Price < 0)
                throw new Exception("Product price is invalid.");

            var newProduct = new Product
            {
                ProductName = product.ProductName,
                Category = product.Category,
                Size = product.Size,
                Price = product.Price,
                Color = product.Color,
            };

            var brand = _brandRepository.GetByName(product.Brand);
            if(brand == null)
            {
                newProduct.Brand = new Brand { BrandName = product.Brand };
            }else
            {
                newProduct.BrandId = brand.BrandId;
            }

            var createdEntity = _productRepository.Add(newProduct);

            return new ProductDto
            {
                ProductId = createdEntity.ProductId,
                ProductName = createdEntity.ProductName,
                Size = createdEntity.Size,
                Color = createdEntity.Color,
                Category = createdEntity.Category,
                Brand = product.Brand                
            };
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();

            var result = products.Select(p => new ProductDto
            {               
                ProductId = p.ProductId,
                ProductName = p.ProductName
            }).ToList();

            return result;
        }

        public UserProductsDto GetAllProductsByUser(int userId)
        {
            var userProducts = _productRepository.GetProductsByUser(userId);
            if (userProducts == null)
                throw new Exception("User not found.");

            return new UserProductsDto
            {
                UserId = userProducts.UserId,
                UserName = userProducts.UserName,
                Products = userProducts.Products.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Size = p.Size,
                    Category = p.Category,
                    Price = p.Price,
                    Brand = p.Brand?.BrandName
                }).ToList()
            };
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                throw new Exception("Product not found.");

            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Size = product.Size,
                Color = product.Color,
                Category = product.Category,
                Brand = product?.Brand.BrandName
            };

        }

        public ProductDto UpdateProduct(int productId, UpdateProductModel product)
        {
            var existingProduct = _productRepository.GetById(productId);
            if (existingProduct == null)
                throw new Exception($"Product with Id {productId} does not exist. ");

            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new Exception("Product name cannot be empty.");

            if (string.IsNullOrWhiteSpace(product.Brand))
                throw new Exception("Brand name cannot be emtpy.");

            if (product.Price == 0F || product.Price < 0)
                throw new Exception("Product price is invalid.");

            existingProduct.ProductName = product.ProductName;
            existingProduct.Category = product.Category;
            existingProduct.Color = product.Color;
            existingProduct.Price = product.Price;
            existingProduct.Size = product.Size;

            var brand = _brandRepository.GetByName(product.Brand);
            if (brand == null)
            {
                existingProduct.Brand = new Brand { BrandName = product.Brand };
            }
            else
            {
                existingProduct.BrandId = brand.BrandId;
            }

            _productRepository.Update(existingProduct);
            return new ProductDto
            {
                ProductId = existingProduct.ProductId,
                ProductName = existingProduct.ProductName,
                Size = existingProduct.Size,
                Color = existingProduct.Color,
                Category = existingProduct.Category,
                Brand = existingProduct.Brand?.BrandName
            };

        }
    }
}
