using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndy.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syndy.Api.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("{brandId:int}/products")]
        public IActionResult GetProductsByBrand([FromRoute]int brandId)
        {
            try
            {
                var products = _brandService.GetProductsByBrand(brandId);
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
