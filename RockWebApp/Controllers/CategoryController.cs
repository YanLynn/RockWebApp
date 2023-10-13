using Microsoft.AspNetCore.Mvc;
using RockWebApp.Controllers.Data;
using RockWebApp.Models;

namespace RockWebApp.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) { 
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategory = _db.Categories.ToList();
            return View(objCategory);
        }

        public IActionResult Create() {

            return View();

        }
    }
}
