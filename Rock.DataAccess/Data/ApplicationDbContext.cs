
using Microsoft.EntityFrameworkCore;
using Rock.Models;

namespace Rock.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "John", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Cherry", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Snow", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Snow", DisplayOrder = 4 }
                );

            modelBuilder.Entity<Product>().HasData(

                
               new Product { 
                   Id = 1, 
                   Title = "Action", 
                   Description = "Abc Egh", 
                   ISBN = "ISBN", 
                   Author = "John Doe", 
                   ListPrice = 40, 
                   Price = 50, 
                   Price50 = 5.7, 
                   Price100 = 100,
                   CategoryId = 1,
                   imgURL = ""
                   },
               new Product
               {
                   Id = 2,
                   Title = "Action",
                   Description = "Abc Egh",
                   ISBN = "ISBN",
                   Author = "John Doe",
                   ListPrice = 40,
                   Price = 50,
                   Price50 = 5.7,
                   Price100 = 100, 
                   CategoryId = 2,
                   imgURL = ""
               },
               new Product
               {
                   Id = 3,
                   Title = "Action",
                   Description = "Abc Egh",
                   ISBN = "ISBN",
                   Author = "John Doe",
                   ListPrice = 40,
                   Price = 50,
                   Price50 = 5.7,
                   Price100 = 100,
                   CategoryId = 3,
                   imgURL = ""
               },
               new Product
               {
                   Id = 4,
                   Title = "Action",
                   Description = "Abc Egh",
                   ISBN = "ISBN",
                   Author = "John Doe",
                   ListPrice = 40,
                   Price = 50,
                   Price50 = 5.7,
                   Price100 = 100,
                   CategoryId = 4,
                   imgURL = ""

               },
               new Product
               {
                   Id = 5,
                   Title = "Action",
                   Description = "Abc Egh",
                   ISBN = "ISBN",
                   Author = "John Doe",
                   ListPrice = 40,
                   Price = 50,
                   Price50 = 5.7,
                   Price100 = 100,
                   CategoryId = 5,
                   imgURL = ""
               },
               new Product
               {
                   Id = 6,
                   Title = "Action",
                   Description = "Abc Egh",
                   ISBN = "ISBN",
                   Author = "John Doe",
                   ListPrice = 40,
                   Price = 50,
                   Price50 = 5.7,
                   Price100 = 100,
                   CategoryId = 1,
                   imgURL = ""
               }


               );
            

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
