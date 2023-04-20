using ehandel.DataAccess.Repository;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ehandel.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _service;

        public CategoryController(IUnitOfWork service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _service.Category.GetAll();
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
        public IActionResult Create(Category obj)
        {
            IEnumerable<Category> objCategoryList = _service.Category.GetAll();

            if (objCategoryList.Any(u => u.Name == obj.Name))
            {
                ModelState.AddModelError("name", "Category name already exists.");
            }

            if (ModelState.IsValid)
            {
                _service.Category.Add(obj);
                _service.Save();
                TempData["success"] = "Added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDb = _service.Category.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _service.Category.Update(obj);
                _service.Save();
                TempData["success"] = "Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDb = _service.Category.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _service.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.Category.Remove(obj);
            _service.Save();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

