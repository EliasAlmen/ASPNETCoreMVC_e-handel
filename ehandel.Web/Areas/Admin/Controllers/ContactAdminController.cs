using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ehandel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactAdminController : Controller
    {
        private readonly IUnitOfWork _service;

        public ContactAdminController(IUnitOfWork service)
        {
            _service = service;
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
