using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ehandel.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IService _service;

        public ContactController(IService service)
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
        public IActionResult Index(ContactUs obj)
        {
            //IEnumerable<ContactUs> objContactUsList = _service.ContactUs.GetAll();

            //if (objContactUsList.Any(u => u.Name == obj.Name))
            //{
            //    ModelState.AddModelError("name", "ContactUs name already exists.");
            //}

            if (ModelState.IsValid)
            {
                _service.ContactUs.Add(obj);
                _service.Save();
                TempData["success"] = "Comment sent successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult CommentList()
        {
            IEnumerable<ContactUs> objContactUsList = _service.ContactUs.GetAll();
            return View(objContactUsList);
        }

    }
}
