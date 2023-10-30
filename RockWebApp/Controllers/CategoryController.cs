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
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString()){
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");
            }
            if(ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully.";
                //you can redirect another controller.... ("action","controller")
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            //Category? category1 = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Category? category2 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["update"] = "Category Updated Successfully.";
                //you can redirect another controller.... ("action","controller")
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["delete"] = "Category Deleted Successfully.";
            //you can redirect another controller.... ("action","controller")
            return RedirectToAction("Index");
          

        }

    }
}
