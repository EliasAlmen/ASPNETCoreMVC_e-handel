using ehandel.DataAccess.Repository;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using ehandel.Models.SD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ehandel.Web.Areas.Admin.Controllers
{
    // AUTH
    [Area(SD.Role_User_Admin)]
    [Authorize(Roles = SD.Role_User_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            // Retrive all categories and return them to the view
            IEnumerable<Category> objCategoryList = await _unitOfWork.Category.GetAllAsync();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category obj)
        {
            IEnumerable<Category> objCategoryList = await _unitOfWork.Category.GetAllAsync();
            //Duplicate enteries
            if (objCategoryList.Any(u => u.Name == obj.Name))
            {
                ModelState.AddModelError("name", "Category name already exists.");
            }
            // All Ok
            if (ModelState.IsValid)
            {
                await _unitOfWork.Category.AddToDbAsync(obj);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            // Should never happen because the button is only displayed if the category exists.
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = await _unitOfWork.Category.GetFirstOrDefaultAsync(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = await _unitOfWork.Category.GetFirstOrDefaultAsync(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var obj = await _unitOfWork.Category.GetFirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

