using Rock.DataAccess.Data;
using Rock.DataAccess.Repository.IRepository;
using Rock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rock.DataAccess.Repository
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
       
        public void Update(Product obj)
        {
           _db.Update(obj);
            var fromDb = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);

            if (fromDb != null)
            {
                fromDb.Title = obj.Title;
                fromDb.Description = obj.Description;
                fromDb.Category = obj.Category;
                fromDb.Price = obj.Price;
                fromDb.ISBN = obj.ISBN;
                fromDb.Author = obj.Author;
                fromDb.ListPrice = obj.ListPrice;
                fromDb.Price100 = obj.Price100;
                fromDb.Price50 = obj.Price50;

                if(fromDb.imgURL != null)
                {
                    fromDb.imgURL = obj.imgURL;
                }
            }

        }
    }
}
