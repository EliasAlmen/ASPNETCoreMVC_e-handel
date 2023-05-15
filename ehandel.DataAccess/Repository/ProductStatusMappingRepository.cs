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
            _db.ProductStatusMappings.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }
    }
}
