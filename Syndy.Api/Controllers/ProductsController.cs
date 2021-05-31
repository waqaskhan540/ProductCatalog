using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndy.Services.Inputs;
using Syndy.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syndy.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateProductModel createProductModel)
        {
            try
            {
                var product = _productService.CreateProduct(createProductModel);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{productId:int}")]
        public IActionResult GetProductById([FromRoute]int productId)
        {
            try
            {
                var product = _productService.GetProductById(productId);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);                
            }
        }
        
        [HttpPut("{productId:int}")]
        public IActionResult Update([FromRoute]int productId, [FromBody] UpdateProductModel productModel)
        {
            try
            {
                var product = _productService.UpdateProduct(productId, productModel);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);                
            }
        }

        [HttpPatch("{productId:int}")]
        public IActionResult ArchiveProduct(int productId, [FromBody] ArchiveProductModel model)
        {
            try
            {
                _productService.ArchiveProduct(productId, model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
