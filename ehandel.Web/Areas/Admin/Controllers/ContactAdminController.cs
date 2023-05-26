using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using ehandel.Models.SD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ehandel.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Pretty much the same as categoryController
    /// </summary>
    [Area(SD.Role_User_Admin)]
    [Authorize(Roles = SD.Role_User_Admin)]
    public class ContactAdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactAdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> CommentList()
        {
            IEnumerable<ContactUs> objContactUsList = await _unitOfWork.ContactUs.GetAllAsync();
            return View(objContactUsList);
        }

        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contactUsFromDb = await _unitOfWork.ContactUs.GetFirstOrDefaultAsync(u => u.Id == id);

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
            var obj = await _unitOfWork.ContactUs.GetFirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ContactUs.Remove(obj);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("CommentList");
        }
    }
}
