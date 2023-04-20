using Microsoft.AspNetCore.Mvc;

namespace ehandel.Web.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
