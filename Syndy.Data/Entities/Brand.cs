using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Data.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
