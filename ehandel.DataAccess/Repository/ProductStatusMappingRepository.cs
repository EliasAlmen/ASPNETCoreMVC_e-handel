using ehandel.DataAccess.Data;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository
{
    public class ProductStatusMappingRepository : Repository<ProductStatusMapping>, IProductStatusMappingRepository
    {
        private ApplicationDbContext _db;

        public ProductStatusMappingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
        public void Update(ProductStatusMapping obj)
        {
            // Attach the ProductStatusMapping object to the DbContext
            _db.ProductStatusMappings.Attach(obj);
            // Set the EntityState of the ProductStatusMapping object to Modified
            _db.Entry(obj).State = EntityState.Modified;
        }
    }
}
