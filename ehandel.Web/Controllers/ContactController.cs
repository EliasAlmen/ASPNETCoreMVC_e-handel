using ehandel.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ehandel.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
