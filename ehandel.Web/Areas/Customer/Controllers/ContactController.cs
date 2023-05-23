using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ehandel.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
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
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactUs obj)
        {
            if (ModelState.IsValid)
            {
                await _service.ContactUs.Add(obj);
                await _service.Save();
                TempData["success"] = "Comment sent successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
