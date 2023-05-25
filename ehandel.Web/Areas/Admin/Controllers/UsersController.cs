using ehandel.Models.SD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ehandel.Web.Areas.Admin.Controllers
{
    [Area(SD.Role_User_Admin)]
    [Authorize(Roles = SD.Role_User_Admin)]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
