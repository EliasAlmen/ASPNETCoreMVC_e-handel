using Bulkybook.DataAccess.Repository;
using Bulkybook.DataAccess.Repository.IRepository;
using ehandel.DataAccess.Data;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            ContactUs = new ContactUsRepository(_db);
            Product = new ProductRepository(_db);
            ProductRating = new ProductRatingRepository(_db);
            ProductStatus = new ProductStatusRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public IContactUsRepository ContactUs { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductRatingRepository ProductRating { get; private set; }
        public IProductStatusRepository ProductStatus { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
