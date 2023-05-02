using ehandel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductStatus>().HasData(
                new ProductStatus
                {
                    Id = 1,
                    Status = "New"
                },
                new ProductStatus
                {
                    Id = 2,
                    Status = "Popular"
                },
                new ProductStatus
                {
                    Id = 3,
                    Status = "Featured"
                }
                );

            modelBuilder.Entity<ProductRating>().HasData(
                new ProductRating
                {
                    Id= 1,
                    Rating = "1"
                },
                new ProductRating
                {
                    Id = 2,
                    Rating = "2"
                },
                new ProductRating
                {
                    Id = 3,
                    Rating = "3"
                },
                new ProductRating
                {
                    Id = 4,
                    Rating = "4"
                },
                new ProductRating
                {
                    Id = 5,
                    Rating = "5"
                }
                );
            //modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        Id = 1,
            //        SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c4",
            //        Name = "Placeholder product",
            //        Description = "Placeholder description",
            //        Price = 99.99,
            //        ImageUrl = "Empty",
            //        CreatedDateTime = "YYYY-MM-DD",
            //        CategoryId = 1,
            //        ProductRatingId = 1,
            //        ProductStatusId = 1
            //        //ProductRating = new ProductRating { Rating = "5" },
            //        //ProductStatus = new ProductStatus { Status = "New"},
            //        //Category = new Category { Name = "Beauty" }
            //    });

        }
    }
}
