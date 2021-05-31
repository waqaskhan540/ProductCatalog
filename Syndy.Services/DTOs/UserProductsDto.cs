using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Services.DTOs
{
    public class UserProductsDto
    {
        public UserProductsDto()
        {
            Products = new List<ProductDto>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
