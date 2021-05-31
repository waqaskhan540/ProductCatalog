using Syndy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Data.Output
{
    public class UserProducts
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public List<Product> Products { get; set; }
    }
}
