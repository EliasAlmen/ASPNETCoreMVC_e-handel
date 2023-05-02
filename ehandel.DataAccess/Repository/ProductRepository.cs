using Bulkybook.DataAccess.Repository.IRepository;
using ehandel.DataAccess.Data;
using ehandel.DataAccess.Repository;
using ehandel.Models;

namespace Bulkybook.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Price = obj.Price;
                objFromDb.Description = obj.Description;
                objFromDb.ProductRatingId = obj.ProductRatingId;
                objFromDb.ProductStatusId = obj.ProductStatusId;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
