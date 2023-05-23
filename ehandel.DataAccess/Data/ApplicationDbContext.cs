﻿using ehandel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductStatusMapping> ProductStatusMappings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserAddress> ApplicationUserAddresses { get; set; }
        public DbSet<ApplicationUserCompany> ApplicationUserCompanies { get; set; }

        // SEED DATA
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Category SEED
            modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Table lamp"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Light"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Bags"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Dress"
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Decoration"
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Essentials"
                    },
                    new Category
                    {
                        Id = 7,
                        Name = "Interior"
                    },
                    new Category
                    {
                        Id = 8,
                        Name = "Laptop"
                    },
                    new Category
                    {
                        Id = 9,
                        Name = "Mobile"
                    },
                    new Category
                    {
                        Id = 10,
                        Name = "Beauty"
                    }
                    );

            #endregion

            #region ProductStatus SEED
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
            #endregion

            #region ProductRating SEED
            modelBuilder.Entity<ProductRating>().HasData(
                    new ProductRating
                    {
                        Id = 1,
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
            #endregion

            #region Product Placeholder SEED
            modelBuilder.Entity<Product>().HasData(
                        new Product
                        {
                            Id = 1,
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c4",
                            Name = "Placeholder product",
                            Description = "Placeholder description",
                            Price = 99,
                            ImageUrl = "\\img\\products\\placeholder.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 1,
                            ProductRatingId = 1
                        });

            #endregion

            #region ProductStatusMapping SEED
            modelBuilder.Entity<ProductStatusMapping>().HasData(
                        new ProductStatusMapping { ProductId = 1, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 1, ProductStatusId = 2 },
                        new ProductStatusMapping { ProductId = 1, ProductStatusId = 3 }
                    );

            #endregion

            #region ContactUs comment SEED
            modelBuilder.Entity<ContactUs>().HasData(
                    new ContactUs
                    {
                        Id = 1,
                        Name = "John Doe",
                        Email = "johndoe@example.com",
                        Phone = "123-456-7890",
                        Company = "Acme Inc.",
                        Comment = "This is a test comment.",
                        TimeOfContact = DateTime.Now
                    },
                    new ContactUs
                    {
                        Id = 2,
                        Name = "Jane Smith",
                        Email = "janesmith@example.com",
                        Phone = "987-654-3210",
                        Company = "XYZ Corporation",
                        Comment = "Lorem ipsum dolor sit amet.",
                        TimeOfContact = DateTime.Now
                    },
                    new ContactUs
                    {
                        Id = 3,
                        Name = "Michael Johnson",
                        Email = "michaeljohnson@example.com",
                        Phone = "555-123-4567",
                        Company = "ABC Industries",
                        Comment = "Testing randomization.",
                        TimeOfContact = DateTime.Now
                    },
                    new ContactUs
                    {
                        Id = 4,
                        Name = "Emily Davis",
                        Email = "emilydavis@example.com",
                        Phone = "111-222-3333",
                        Company = "Global Enterprises",
                        Comment = "Hello world!",
                        TimeOfContact = DateTime.Now
                    },
                    new ContactUs
                    {
                        Id = 5,
                        Name = "David Brown",
                        Email = "davidbrown@example.com",
                        Phone = "444-555-6666",
                        Company = "Smith & Co.",
                        Comment = "Random comment here.",
                        TimeOfContact = DateTime.Now
                    }
                ); 
            #endregion

        }
    }
}
