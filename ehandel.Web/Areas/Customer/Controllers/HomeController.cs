using ehandel.DataAccess.Repository;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using ehandel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ehandel.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> productList = await _service.Product.GetAll(includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");
            return View(productList);
        }

        public async Task<IActionResult> Details(int productId)
        {
            var productDetail = await _service.Product.GetFirstOrDefault(u => u.Id == productId, includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");
            return View(productDetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}