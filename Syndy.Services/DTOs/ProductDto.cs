using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Services.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Size { get; set; }
        public string Color { get; set; }       
        public string Category { get; set; }                
        public string Brand { get; set; }
        public float Price { get; set; }
    }
}
