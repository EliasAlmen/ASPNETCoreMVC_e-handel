using ehandel.Models;
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
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c1",
                            Name = "The Apple Watch Series",
                            Description = "The Apple Watch Series is a cutting-edge wearable device that seamlessly integrates with your iPhone, providing a range of innovative features and functionalities. With its sleek design and advanced technology, it allows you to stay connected, track your fitness, monitor your health, access apps, and receive notifications, all from your wrist.",
                            Price = 30,
                            ImageUrl = "\\img\\placeholders\\270x295.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 9,
                            ProductRatingId = 4
                        },
                        new Product
                        {
                            Id = 2,
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c2",
                            Name = "Table lamp",
                            Description = "The Table Lamp is a versatile lighting fixture that adds both functionality and style to any space. With its sleek design and adjustable brightness, it provides the perfect ambiance for reading, working, or creating a cozy atmosphere. Its compact size and sturdy base make it an ideal choice for bedside tables, desks, or any tabletop surface.",
                            Price = 30,
                            ImageUrl = "\\img\\placeholders\\270x295.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 1,
                            ProductRatingId = 3
                        },
                        new Product
                        {
                            Id = 3,
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c3",
                            Name = "Laptop thinkpad lenovo",
                            Description = "The ThinkPad Lenovo laptop is a powerful computing device known for its reliability and performance. Designed for professionals and business users, it offers a robust build, exceptional keyboard, and advanced security features. With its high-quality display, fast processing power, and extensive connectivity options, it empowers users to accomplish tasks efficiently and enhance productivity.",
                            Price = 30,
                            ImageUrl = "\\img\\placeholders\\270x295.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 8,
                            ProductRatingId = 5
                        },
                        new Product
                        {
                            Id = 4,
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c4",
                            Name = "Gumshoes black fashion",
                            Description = "Black fashion gumshoes are a trendy footwear choice that combines style and comfort. These sleek and versatile shoes feature a classic black color, making them easy to match with various outfits. With their cushioned soles and breathable materials, they provide all-day comfort for walking or casual wear. Perfect for fashion-forward individuals seeking a blend of elegance and functionality.",
                            Price = 80,
                            ImageUrl = "\\img\\placeholders\\270x295.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 8,
                            ProductRatingId = 5
                        },
                        new Product
                        {
                            Id = 5,
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c5",
                            Name = "Woman white dress",
                            Description = "The woman's white dress is an elegant and timeless piece that exudes grace and sophistication. Its pristine white color symbolizes purity and femininity, while the flowing fabric drapes beautifully to enhance the wearer's silhouette. Whether worn for a special occasion or a casual outing, this dress radiates effortless style and captures the essence of femininity.",
                            Price = 30,
                            ImageUrl = "\\img\\placeholders\\270x295.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 4,
                            ProductRatingId = 5
                        },
                        new Product
                        {
                            Id = 6,
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c6",
                            Name = "Kettle water boiler",
                            Description = "The kettle water boiler is a convenient and efficient appliance designed to quickly heat water for various purposes. With its sleek and compact design, it effortlessly fits into any kitchen space. Boasting rapid boiling capabilities, it provides hot water in a matter of minutes, making it ideal for brewing tea, coffee, or preparing instant meals. Its easy-to-use features and safety mechanisms ensure a hassle-free and enjoyable boiling experience.",
                            Price = 30,
                            ImageUrl = "\\img\\placeholders\\270x295.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 6,
                            ProductRatingId = 1
                        },
                        new Product
                        {
                            Id = 7,
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c7",
                            Name = "Congee rice cooker",
                            Description = "The congee cooking rice cooker is a versatile kitchen appliance that simplifies the process of making congee, a traditional rice porridge dish. With its advanced features and settings, it ensures perfectly cooked and creamy congee every time. Whether you prefer a smooth or chunky texture, this cooker delivers consistent results, making it a convenient choice for congee lovers.",
                            Price = 30,
                            ImageUrl = "\\img\\placeholders\\270x295.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 6,
                            ProductRatingId = 1
                        },
                        new Product
                        {
                            Id = 8,
                            SKU = "04acc686-02ca-4e4a-adc1-cb6bb3f297c8",
                            Name = "Pizza tomato sauce kebab",
                            Description = "Pizza tomato sauce kebab is a delicious fusion dish that combines the flavors of traditional pizza with the savory taste of kebab. It features a thin crust layered with tangy tomato sauce and topped with tender kebab meat, vegetables, and melted cheese. The combination of these ingredients creates a mouthwatering and satisfying culinary experience that is sure to please pizza and kebab enthusiasts alike.",
                            Price = 30,
                            ImageUrl = "\\img\\placeholders\\270x295.svg",
                            CreatedDateTime = DateTime.Now.ToString("g"),
                            CategoryId = 6,
                            ProductRatingId = 1
                        }
                        );

            #endregion

            #region ProductStatusMapping SEED
            modelBuilder.Entity<ProductStatusMapping>().HasData(
                        new ProductStatusMapping { ProductId = 1, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 1, ProductStatusId = 2 },

                        new ProductStatusMapping { ProductId = 2, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 2, ProductStatusId = 2 },

                        new ProductStatusMapping { ProductId = 3, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 3, ProductStatusId = 2 },

                        new ProductStatusMapping { ProductId = 4, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 4, ProductStatusId = 2 },

                        new ProductStatusMapping { ProductId = 5, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 5, ProductStatusId = 2 },

                        new ProductStatusMapping { ProductId = 6, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 6, ProductStatusId = 2 },

                        new ProductStatusMapping { ProductId = 7, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 7, ProductStatusId = 2 },
                        new ProductStatusMapping { ProductId = 7, ProductStatusId = 3 },

                        new ProductStatusMapping { ProductId = 8, ProductStatusId = 1 },
                        new ProductStatusMapping { ProductId = 8, ProductStatusId = 2 },
                        new ProductStatusMapping { ProductId = 8, ProductStatusId = 3 }
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
