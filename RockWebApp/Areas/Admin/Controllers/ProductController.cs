using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rock.DataAccess.Data;
using Rock.DataAccess.Repository.IRepository;
using Rock.Models;
using Rock.Models.ViewModels;
using Rock.Utility;
using System.Collections.Generic;

namespace RockWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment; //accept wwwroot folder

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProduct = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
            
            return View(objProduct);
        }

        public IActionResult Upsert(int? id) // update inert (combine)
        {

            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Product = new Product()

            };
            if(id == 0 || id == null)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
            

        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        { 
            
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file!= null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string Productpath = Path.Combine(wwwRootPath, @"images\Product");

                    if (!string.IsNullOrEmpty(obj.Product.imgURL))
                    {
                        var oldImgPath = Path.Combine(wwwRootPath, obj.Product.imgURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }
                    
                    using ( var fileStream = new FileStream(Path.Combine(Productpath,fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.Product.imgURL = @"\images\Product\" + fileName;
                }
                
                if (obj.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                    
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                    
                }
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully.";
                //you can redirect another controller.... ("action","controller")
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });

                return View(obj);
            }
            

        }

     


        #region Api call

        [HttpGet, ActionName("GetAll")]
        public IActionResult GetAll() {

            List<Product> objProduct = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new {data = objProduct});
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int? id)
        {
            var obj = _unitOfWork.Product.Get(u => u.Id == id);
            if(obj == null)
            {
                return Json(new {success =  false, message="Error while deleting."});
            }
            var oldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, obj.imgURL.TrimStart('\\'));
            if (System.IO.File.Exists(oldImgPath))
            {
                System.IO.File.Delete(oldImgPath);
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful." });

        }

        #endregion

    }
}
