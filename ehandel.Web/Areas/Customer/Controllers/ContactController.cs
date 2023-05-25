using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using ehandel.Models.SD;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ehandel.Web.Areas.Customer.Controllers
{
    [Area(SD.Role_User_Customer)]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                await _unitOfWork.ContactUs.AddToDbAsync(obj);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Comment sent successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
