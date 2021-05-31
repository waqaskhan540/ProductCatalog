using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Data.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Size { get; set; }
        public string Color { get; set; }       
        public string Category { get; set; }
        public bool IsArchived { get; set; } = false;
        
        public float Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
      
        public virtual ICollection<UserProduct> UserProducts { get; set; }

    }
}
