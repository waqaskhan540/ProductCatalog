using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Data.Entities
{
    public class UserProduct
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
