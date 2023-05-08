using Bulkybook.Models.ViewModels;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Linq;

namespace ehandel.Web.Controllers
{
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _service;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductController(IWebHostEnvironment webHostEnvironment, IUnitOfWork service)
		{
			_webHostEnvironment = webHostEnvironment;
			_service = service;
		}

		public IActionResult Index()
		{
			return View();
		}


        //GET
        public async Task<IActionResult> Upsert(int? id)
        {
            ProductVM productVM = new ProductVM
            {
                Product = new Product(),
                CategoryList = (await _service.Category.GetAll()).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                RatingsList = (await _service.ProductRating.GetAll()).Select(i => new SelectListItem
                {
                    Text = i.Rating,
                    Value = i.Id.ToString()
                })
            };

            // Check if there is a product with the given id
            if (id != null && id != 0)
            {
                // Get the product and its associated status mappings
                productVM.Product = await _service.Product.GetFirstOrDefault(u => u.Id == id);
                if (productVM.Product == null)
                {
                    return NotFound();
                }

                // Retrieve the existing status mappings for the product
                productVM.Product.ProductStatusMappings = await _service.ProductStatusMapping.GetByProductIdAsync(id.Value);
            }

            // Get the list of all statuses
            var allStatuses = await _service.ProductStatus.GetAll();

            // Set the list of statuses to the StatusList property of the view model
            productVM.StatusList = allStatuses.Select(i => new SelectListItem
            {
                Text = i.Status,
                Value = i.Id.ToString(),
                Selected = productVM.Product.ProductStatusMappings != null && productVM.Product.ProductStatusMappings.Any(psm => psm.ProductStatusId == i.Id)
            });

            return View(productVM);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductVM obj, IFormFile? file)
        {
            int productId = obj.Product.Id;

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"img/products");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageUrl = @"\img\products\" + fileName + extension;
                }

                // Remove all existing status mappings
                List<ProductStatusMapping> existingStatusMappings = await _service.ProductStatusMapping.GetByProductIdAsync(obj.Product.Id);
                _service.ProductStatusMapping.RemoveRange(existingStatusMappings);

                // Loop through the selected status values and create new status mappings
                foreach (var statusId in obj.SelectedStatuses)
                {
                    if (int.TryParse(statusId, out int parsedStatusId))
                    {
                        // Create a new ProductStatusMapping object
                        var newMapping = new ProductStatusMapping
                        {
                            ProductId = obj.Product.Id,
                            ProductStatusId = parsedStatusId,
                            Product = obj.Product  // Set the Product navigation property
                        };

                        // Add the mapping to the database
                        await _service.ProductStatusMapping.Add(newMapping);
                    }
                }

                // Update the product entity
                var existingProduct = await _service.Product.GetByIdAsync(obj.Product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = obj.Product.Name;
                    existingProduct.ProductRating = obj.Product.ProductRating;
                    // Update other properties as needed

                    _service.Product.Update(existingProduct);
                }

                await _service.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        #region API CALLS
        [HttpGet]
		public async Task<IActionResult> GetAll()
		{
			//todo: NOT WORKING!
			var productList = await _service.Product.GetAll(includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");
			return Json(new { data = productList });
		}

		//POST
		[HttpDelete]
		public async Task<IActionResult> Delete(int? id)
		{
			var obj = await _service.Product.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}

			_service.Product.Remove(obj);
			await _service.Save();
			return Json(new { success = true, message = "Delete successful" });

		}
		#endregion
	}
}
