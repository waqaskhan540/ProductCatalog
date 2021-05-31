using Microsoft.EntityFrameworkCore;
using Syndy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Data.Context
{
    public class SyndyDataContext : DbContext, ISyndyDataContext
    {
        public SyndyDataContext(DbContextOptions<SyndyDataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<UserProduct> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserProduct>().HasKey(u => new { u.UserId, u.ProductId });
            modelBuilder.Entity<UserProduct>().HasOne(x => x.User).WithMany(t => t.UserProducts).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserProduct>().HasOne(x => x.Product).WithMany(t => t.UserProducts).HasForeignKey(x => x.ProductId);
           

            SeedBrands(modelBuilder);
            SeedUsers(modelBuilder);
            SeedProducts(modelBuilder);
            SeedUserProducts(modelBuilder);
        }

        private void SeedBrands(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, BrandName = "H&M" },
                new Brand { BrandId = 2, BrandName = "Coop"},
                new Brand { BrandId = 3, BrandName = "Spar"},
                new Brand { BrandId = 4, BrandName = "Tesco"},
                new Brand { BrandId = 5, BrandName = "Decathlon"}
                );
            
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, FirstName = "Muhammad", LastName = "Waqas" });
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Jacket", BrandId = 1, Category = "Garments", Color = "Black" , Size = "XL", Price = 12.4F },
                new Product { ProductId = 2, ProductName = "Cap", BrandId = 1, Category = "Garments", Color = "Black", Size = "XL", Price = 15.4F },
                new Product { ProductId = 3, ProductName = "Jeans", BrandId = 1, Category = "Garments", Color = "Black", Size = "XL", Price = 17.4F },

                new Product { ProductId = 4, ProductName = "Children's Banana 5 Pieces", BrandId = 2, Category = "Fruits", Price = 1.19F },
                new Product { ProductId = 5, ProductName = "Haribo Banan 240 g", BrandId = 2, Category = "Fruits", Price = 1.49F },
                new Product { ProductId = 6, ProductName = "Eggplan", BrandId = 2, Category = "Vegetables", Price = 0.74F },

                new Product { ProductId = 7, ProductName = "Toilet Paper", BrandId = 3, Category = "Sanitory", Price = 1.19F },
                new Product { ProductId = 8, ProductName = "Coke", BrandId = 3, Category = "Beverages", Price = 1.49F },
                new Product { ProductId = 9, ProductName = "Kinder Egg", BrandId = 3, Category = "Chocolates", Price = 0.74F },

                new Product { ProductId = 10, ProductName = "Coke", BrandId = 4, Category = "Beverages", Price = 1.60F },
                new Product { ProductId = 11, ProductName = "Shoes", BrandId = 5, Category = "Sports", Size = "36" , Color = "Blue", Price = 0.74F }
               );
        }

        private void SeedUserProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProduct>().HasData(
                    new UserProduct { UserId = 1, ProductId = 1 },
                    new UserProduct { UserId = 1, ProductId = 5 },
                    new UserProduct { UserId = 1, ProductId = 7 }
                    );
        }
    }
}
