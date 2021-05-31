using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Services.Inputs
{
    public class CreateProductModel
    {
        public string ProductName { get; set; }

        public string Size { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public float Price { get; set; }
    }
}
