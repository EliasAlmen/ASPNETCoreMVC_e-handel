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
    public class ProductRatingRepository : Repository<ProductRating>, IProductRatingRepository
    {
        private ApplicationDbContext _db;

        public ProductRatingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductRating obj)
        {
            _db.ProductRatings.Update(obj);
        }
    }
}
