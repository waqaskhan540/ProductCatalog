using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndy.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syndy.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IProductService _productService;

        public UsersController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{userId:int}/products")]
        public IActionResult GetProductsByUser(int userId)
        {
            try
            {
                var userproducts = _productService.GetAllProductsByUser(userId);
                return Ok(userproducts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
