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
            // Check if it's the user's first visit
            if (IsFirstVisit())
            {
                // Set a flag or cookie to indicate that the user has visited before
                SetVisitedCookie();

                // Render the view for the information window
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

        public IActionResult Info()
        {
            return View("InformationWindow");
        }

        public async Task<IActionResult> Details(int productId)
        {
            var productDetail = await _unitOfWork.Product.GetFirstOrDefaultAsync(u => u.Id == productId, includeProperties: "Category,ProductRating,ProductStatusMappings.ProductStatus");
            return View(productDetail);
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


        // Check if it's the user's first visit by checking for the presence of a cookie
        private bool IsFirstVisit()
        {
            // Check if the "Visited" cookie exists
            var visitedCookie = Request.Cookies["Visited"];
            return string.IsNullOrEmpty(visitedCookie);
        }

        // Set a cookie to indicate that the user has visited before
        private void SetVisitedCookie()
        {
            // Create a "Visited" cookie with an expiration date
            var visitedCookie = new CookieOptions
            {
                // Set the cookie expiration date to a future date
                Expires = DateTime.Now.AddMinutes(10)
            };

            // Set the value of the cookie
            Response.Cookies.Append("Visited", "true", visitedCookie);
        }


    }
}