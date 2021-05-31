﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Syndy.Data.Context;

namespace Syndy.Data.Migrations
{
    [DbContext(typeof(SyndyDataContext))]
    partial class SyndyDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Syndy.Data.Entities.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            BrandName = "H&M"
                        },
                        new
                        {
                            BrandId = 2,
                            BrandName = "Coop"
                        },
                        new
                        {
                            BrandId = 3,
                            BrandName = "Spar"
                        },
                        new
                        {
                            BrandId = 4,
                            BrandName = "Tesco"
                        },
                        new
                        {
                            BrandId = 5,
                            BrandName = "Decathlon"
                        });
                });

            modelBuilder.Entity("Syndy.Data.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            BrandId = 1,
                            Category = "Garments",
                            Color = "Black",
                            IsArchived = false,
                            Price = 12.4f,
                            ProductName = "Jacket",
                            Size = "XL"
                        },
                        new
                        {
                            ProductId = 2,
                            BrandId = 1,
                            Category = "Garments",
                            Color = "Black",
                            IsArchived = false,
                            Price = 15.4f,
                            ProductName = "Cap",
                            Size = "XL"
                        },
                        new
                        {
                            ProductId = 3,
                            BrandId = 1,
                            Category = "Garments",
                            Color = "Black",
                            IsArchived = false,
                            Price = 17.4f,
                            ProductName = "Jeans",
                            Size = "XL"
                        },
                        new
                        {
                            ProductId = 4,
                            BrandId = 2,
                            Category = "Fruits",
                            IsArchived = false,
                            Price = 1.19f,
                            ProductName = "Children's Banana 5 Pieces"
                        },
                        new
                        {
                            ProductId = 5,
                            BrandId = 2,
                            Category = "Fruits",
                            IsArchived = false,
                            Price = 1.49f,
                            ProductName = "Haribo Banan 240 g"
                        },
                        new
                        {
                            ProductId = 6,
                            BrandId = 2,
                            Category = "Vegetables",
                            IsArchived = false,
                            Price = 0.74f,
                            ProductName = "Eggplan"
                        },
                        new
                        {
                            ProductId = 7,
                            BrandId = 3,
                            Category = "Sanitory",
                            IsArchived = false,
                            Price = 1.19f,
                            ProductName = "Toilet Paper"
                        },
                        new
                        {
                            ProductId = 8,
                            BrandId = 3,
                            Category = "Beverages",
                            IsArchived = false,
                            Price = 1.49f,
                            ProductName = "Coke"
                        },
                        new
                        {
                            ProductId = 9,
                            BrandId = 3,
                            Category = "Chocolates",
                            IsArchived = false,
                            Price = 0.74f,
                            ProductName = "Kinder Egg"
                        },
                        new
                        {
                            ProductId = 10,
                            BrandId = 4,
                            Category = "Beverages",
                            IsArchived = false,
                            Price = 1.6f,
                            ProductName = "Coke"
                        },
                        new
                        {
                            ProductId = 11,
                            BrandId = 5,
                            Category = "Sports",
                            Color = "Blue",
                            IsArchived = false,
                            Price = 0.74f,
                            ProductName = "Shoes",
                            Size = "36"
                        });
                });

            modelBuilder.Entity("Syndy.Data.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "Muhammad",
                            LastName = "Waqas"
                        });
                });

            modelBuilder.Entity("Syndy.Data.Entities.UserProduct", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserProducts");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            UserId = 1,
                            ProductId = 5
                        },
                        new
                        {
                            UserId = 1,
                            ProductId = 7
                        });
                });

            modelBuilder.Entity("Syndy.Data.Entities.Product", b =>
                {
                    b.HasOne("Syndy.Data.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Syndy.Data.Entities.UserProduct", b =>
                {
                    b.HasOne("Syndy.Data.Entities.Product", "Product")
                        .WithMany("UserProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Syndy.Data.Entities.User", "User")
                        .WithMany("UserProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Syndy.Data.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Syndy.Data.Entities.Product", b =>
                {
                    b.Navigation("UserProducts");
                });

            modelBuilder.Entity("Syndy.Data.Entities.User", b =>
                {
                    b.Navigation("UserProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
