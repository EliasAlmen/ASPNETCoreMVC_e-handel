﻿using Bulkybook.Models.ViewModels;
using ehandel.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
			ProductVM productVM = new()
			{
				Product = new(),
				CategoryList = (await _service.Category.GetAll()).Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				}),
				RatingsList = (await _service.ProductRating.GetAll()).Select(i => new SelectListItem
				{
					Text = i.Rating,
					Value = i.Id.ToString()
				}),

                StatusList = (await _service.ProductStatus.GetAll()).Select(i => new SelectListItem
                {
                    Text = i.Status,
                    Value = i.Id.ToString()
                })
            };

			if (id == null || id == 0)
			{
				// Create product
				//ViewBag.CategoryList = CategoryList;
				//ViewData["CoverTypeList"] = CoverTypeList;
				return View(productVM);
			}
			else
			{
				productVM.Product = await _service.Product.GetFirstOrDefault(u => u.Id == id);
				// Update product
				return View(productVM);
			}


		}

		//POST
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
				if (obj.Product.Id == 0)
				{
					await _service.Product.Add(obj.Product);
				}
				else
				{
					_service.Product.Update(obj.Product);
				}
				await _service.Save();
				TempData["success"] = "Product created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		#region API CALLS
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var productList = await _service.Product.GetAll(includeProperties: "Category,ProductRating,ProductStatus");
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
