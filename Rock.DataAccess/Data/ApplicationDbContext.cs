
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rock.Models;

namespace Rock.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //*******
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "John", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Cherry", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Snow", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Snow", DisplayOrder = 4 }
                );
            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 1,
                   Name = "Tech Solution",
                   StreetAddress = "123 Tech St",
                   City = "Tech City",
                   PostalCode = "12121",
                   State = "IL",
                   PhoneNumber = "6669990000"
               },
               new Company
               {
                   Id = 2,
                   Name = "Vivid Books",
                   StreetAddress = "999 Vid St",
                   City = "Vid City",
                   PostalCode = "66666",
                   State = "IL",
                   PhoneNumber = "7779990000"
               },
               new Company
               {
                   Id = 3,
                   Name = "Readers Club",
                   StreetAddress = "999 Main St",
                   City = "Lala land",
                   PostalCode = "99999",
                   State = "NY",
                   PhoneNumber = "1113335555"
               }
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
