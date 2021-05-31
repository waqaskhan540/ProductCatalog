﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<UserProduct> UserProducts { get; set; }
    }
}
