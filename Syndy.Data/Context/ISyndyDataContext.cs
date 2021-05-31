using Microsoft.EntityFrameworkCore;
using Syndy.Data.Entities;

namespace Syndy.Data.Context
{
    public interface ISyndyDataContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; }
       
    }
}