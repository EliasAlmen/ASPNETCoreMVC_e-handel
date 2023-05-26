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

    /// <summary>
    /// UNIT OF WORK PATTERN
    /// </summary>
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
            ProductStatusMapping = new ProductStatusMappingRepository(_db);
            ApplicationUserAddress = new ApplicationUserAddressRepository(_db);
            ApplicationUserCompany = new ApplicationUserCompanyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public IContactUsRepository ContactUs { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductRatingRepository ProductRating { get; private set; }
        public IProductStatusRepository ProductStatus { get; private set; }
        public IProductStatusMappingRepository ProductStatusMapping { get; private set; }
        public IApplicationUserAddressRepository ApplicationUserAddress { get; private set; }
        public IApplicationUserCompanyRepository ApplicationUserCompany { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
