using Microsoft.AspNetCore.Mvc;
using Rock.DataAccess.Repository;
using Rock.DataAccess.Repository.IRepository;
using Rock.Models;
using System.Diagnostics;

namespace RockWebApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfwork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfwork.Product.GetAll(includeProperties:"Category");
            return View(productList);
        }
        public IActionResult Details(int? productId)
        {
            Product product = _unitOfwork.Product.Get(u => u.Id == productId, includeProperties: "Category");
            return View(product);
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