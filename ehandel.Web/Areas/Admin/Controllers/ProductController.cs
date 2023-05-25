using ehandel.DataAccess.Repository;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using ehandel.Models.SD;
using ehandel.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Data;
using System.Linq;

namespace ehandel.Web.Areas.Admin.Controllers
{
    [Area(SD.Role_User_Admin)]
    [Authorize(Roles = SD.Role_User_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        // GET
        public async Task<IActionResult> Upsert(int? id)
        {
            ProductVM productVM;

            if (id == null || id == 0)
            {
                productVM = new ProductVM
                {
                    CategoryList = (await _unitOfWork.Category.GetAllAsync()).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    RatingsList = (await _unitOfWork.ProductRating.GetAllAsync()).Select(i => new SelectListItem
                    {
                        Text = i.Rating,
                        Value = i.Id.ToString()
                    }),
                    StatusList = (await _unitOfWork.ProductStatus.GetAllAsync()).Select(i => new SelectListItem
                    {
                        Text = i.Status,
                        Value = i.Id.ToString()
                    })
                };
            }
            else
            {
                var existingProduct = await _unitOfWork.Product.GetFirstOrDefaultAsync(u => u.Id == id, "Category,ProductRating,ProductStatusMappings.ProductStatus");

                if (existingProduct == null)
                {
                    return NotFound();
                }

                productVM = new ProductVM
                {
                    Id = existingProduct.Id,
                    Description = existingProduct.Description,
                    Name = existingProduct.Name,
                    Price = existingProduct.Price,
                    ImageUrl = existingProduct.ImageUrl,

                    // Map nested properties
                    CategoryId = existingProduct.CategoryId,
                    ProductRatingId = existingProduct.ProductRatingId,

                    CategoryList = (await _unitOfWork.Category.GetAllAsync())
                        .Select(c => new SelectListItem
                        {
                            Text = c.Name,
                            Value = c.Id.ToString(),
                            Selected = c.Id == existingProduct.CategoryId
                        })
                        .ToList(),

                    RatingsList = (await _unitOfWork.ProductRating.GetAllAsync())
                        .Select(r => new SelectListItem
                        {
                            Text = r.Rating,
                            Value = r.Id.ToString(),
                            Selected = r.Id == existingProduct.ProductRatingId
                        })
                        .ToList()
                };

                var productStatusMappings = existingProduct.ProductStatusMappings;
                var selectedStatuses = productStatusMappings?.Select(m => m.ProductStatusId).ToList() ?? new List<int>();

                // Check if selectedStatuses is null and initialize as an empty list
                if (selectedStatuses == null)
                {
                    selectedStatuses = new List<int>();
                }

                var allStatuses = await _unitOfWork.ProductStatus.GetAllAsync();

                productVM.StatusList = allStatuses
                    .Select(s => new SelectListItem
                    {
                        Text = s.Status,
                        Value = s.Id.ToString(),
                        Selected = selectedStatuses.Contains(s.Id)
                    })
                    .ToList();

            }

            return View(productVM);

        }




        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"img/products");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.ImageUrl = @"\img\products\" + fileName + extension;
                }

                if (obj.Id == 0)
                {
                    // Add a new product
                    await _unitOfWork.Product.AddToDbAsync(obj);
                    await _unitOfWork.SaveAsync();
                }

                else
                {
                    // Update an existing product
                    var existingProduct = await _unitOfWork.Product.GetByIdAsync(obj.Id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }

                    existingProduct.Name = obj.Name;
                    existingProduct.Description = obj.Description;
                    existingProduct.Price = obj.Price;
                    existingProduct.ProductRatingId = obj.ProductRatingId;
                    existingProduct.CategoryId = obj.CategoryId;

                    var updateModel = new ProductVM
                    {
                        Id = existingProduct.Id,
                        Name = existingProduct.Name,
                        Price = existingProduct.Price,
                        Description = existingProduct.Description,
                        ProductRatingId = existingProduct.ProductRatingId,
                        CategoryId = existingProduct.CategoryId,
                        SelectedStatuses = obj.SelectedStatuses ?? new List<int>(),
                        ImageUrl = obj.ImageUrl
                    };

                    await _unitOfWork.Product.UpdateAsync(updateModel);
                    await _unitOfWork.SaveAsync();

                    TempData["success"] = "Product updated successfully";
                    return RedirectToAction("Index");
                }

                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            // Model is not valid, return to the view with validation errors
            obj.CategoryList = (await _unitOfWork.Category.GetAllAsync()).Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            obj.RatingsList = (await _unitOfWork.ProductRating.GetAllAsync()).Select(i => new SelectListItem
            {
                Text = i.Rating,
                Value = i.Id.ToString()
            });

            // Populate the status list
            obj.StatusList = (await _unitOfWork.ProductStatus.GetAllAsync()).Select(s => new SelectListItem
            {
                Text = s.Status,
                Value = s.Id.ToString()
            });

            return View(obj);
        }




        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productList = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");

            // Iterate through the product list and update the status name
            foreach (var product in productList)
            {
                foreach (var productStatusMapping in product.ProductStatusMappings)
                {
                    var productStatus = await _unitOfWork.ProductStatus.GetByIdAsync(productStatusMapping.ProductStatusId);
                    productStatusMapping.ProductStatus.Status = productStatus.Status;
                }
            }

            return Json(new { data = productList });
        }

        //POST
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _unitOfWork.Product.GetFirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(obj);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true, message = "Delete successful" });

        }
        #endregion
    }
}
