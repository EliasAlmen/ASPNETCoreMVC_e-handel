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
    public class ProductStatusRepository : Repository<ProductStatus>, IProductStatusRepository
    {
        private ApplicationDbContext _db;

        public ProductStatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductStatus obj)
        {
            _db.ProductStatuses.Update(obj);
        }
    }
}
