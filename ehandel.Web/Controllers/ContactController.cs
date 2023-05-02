using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ehandel.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _service;

        public ContactController(IUnitOfWork service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
            // todo: CRUD
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactUs obj)
        {
            //IEnumerable<ContactUs> objContactUsList = _service.ContactUs.GetAll();

            //if (objContactUsList.Any(u => u.Name == obj.Name))
            //{
            //    ModelState.AddModelError("name", "ContactUs name already exists.");
            //}

            if (ModelState.IsValid)
            {
                await _service.ContactUs.Add(obj);
                await _service.Save();
                TempData["success"] = "Comment sent successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public async Task<IActionResult> CommentList()
        {
            IEnumerable<ContactUs> objContactUsList = await _service.ContactUs.GetAll();
            return View(objContactUsList);
        }

        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var contactUsFromDb = _db.Categories.Find(id);
            var contactUsFromDb = await _service.ContactUs.GetFirstOrDefault(u => u.Id == id);

            if (contactUsFromDb == null)
            {
                return NotFound();
            }

            return View(contactUsFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var obj = await _service.ContactUs.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.ContactUs.Remove(obj);
            await _service.Save();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("CommentList");
        }

    }
}
