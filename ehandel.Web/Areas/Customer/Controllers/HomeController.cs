using ehandel.DataAccess.Repository;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using ehandel.Models.SD;
using ehandel.Models.viewModels;
using ehandel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ehandel.Web.Areas.Customer.Controllers
{
    [Area(SD.Role_User_Customer)]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            //If no cookie!
            if (IsFirstVisit())
            {
                SetVisitedCookie();

                return View("InformationWindow");
            }

            //Get products based on properties
            IEnumerable<Product> productListAll = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");
            
            IEnumerable<Category> categoriesList = await _unitOfWork.Category.GetAllAsync();

            //Set VM with above 
            var HomeIndexVM = new HomeIndexVM
            {
                AllProducts = productListAll,
                CategoryList = categoriesList
            };

            return View(HomeIndexVM);
        }

        // Added a page for viewing the information
        public IActionResult Info()
        {
            return View("InformationWindow");
        }

        public async Task<IActionResult> Details(int productId)
        {

            var productDetail = await _unitOfWork.Product.GetFirstOrDefaultAsync(u => u.Id == productId, includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");
            // Get related products
            IEnumerable<Product> productRelated = await _unitOfWork.Product.GetAllAsync(u => u.CategoryId == productDetail.CategoryId, includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");
            
            var DetailsVM = new DetailsVM
            {
                RelatedProducts = productRelated,
                Product = productDetail
            };
            
            return View(DetailsVM);
        }

        public async Task<IActionResult> Products()
        {
            IEnumerable<Product> productListAll = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");

            return View(productListAll);
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

        // See if user already visited
        private bool IsFirstVisit()
        {
            var visitedCookie = Request.Cookies["Visited"];
            return string.IsNullOrEmpty(visitedCookie);
        }

        // Set visisted cookie, 10minutes
        private void SetVisitedCookie()
        {
            var visitedCookie = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(10)
            };

            Response.Cookies.Append("Visited", "true", visitedCookie);
        }
    }
}