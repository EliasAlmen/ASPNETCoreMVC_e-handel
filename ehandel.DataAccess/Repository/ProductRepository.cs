
using ehandel.DataAccess.Data;
using ehandel.DataAccess.Repository;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using ehandel.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ehandel.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }

        // Alot of help from GPT here. It spun out of control for my envisoned feature for setting statuses. 
        // There were so many different scenarios. for example if a product has no statuses, one or several statuses. Or if i only update one status.
        // Or maybe I dont update statuses at all. Either way I can not take full credit for this logic.
        // But am i glad that I did it and saw it trough? awnser: yes.
        public async Task UpdateAsync(ProductVM obj)
        {
            var objFromDb = await _db.Products
                .Include(p => p.ProductStatusMappings)
                .FirstOrDefaultAsync(u => u.Id == obj.Id);

            if (objFromDb == null)
            {
                return;
            }

            objFromDb.Name = obj.Name;
            objFromDb.Price = obj.Price;
            objFromDb.Description = obj.Description;
            objFromDb.ProductRatingId = obj.ProductRatingId;
            objFromDb.CategoryId = obj.CategoryId;

            var selectedStatusIds = obj.SelectedStatuses ?? new List<int>();

            // Remove mappings that are no longer selected
            var mappingsToRemove = objFromDb.ProductStatusMappings
                .Where(m => !selectedStatusIds.Contains(m.ProductStatusId))
                .ToList();

            foreach (var mappingToRemove in mappingsToRemove)
            {
                objFromDb.ProductStatusMappings.Remove(mappingToRemove);
            }

            // Add or update mappings
            foreach (var productStatusId in selectedStatusIds)
            {
                var existingMapping = objFromDb.ProductStatusMappings
                    .FirstOrDefault(m => m.ProductStatusId == productStatusId);

                if (existingMapping != null)
                {
                    // Update the existing mapping
                    existingMapping.ProductStatusId = productStatusId;
                }
                else
                {
                    // Add a new mapping
                    var newMapping = new ProductStatusMapping
                    {
                        ProductId = objFromDb.Id,
                        ProductStatusId = productStatusId
                    };
                    objFromDb.ProductStatusMappings.Add(newMapping);
                }
            }

            if (obj.ImageUrl != null)
            {
                objFromDb.ImageUrl = obj.ImageUrl;
            }
        }
    }
}
