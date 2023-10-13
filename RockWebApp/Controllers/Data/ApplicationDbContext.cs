using Microsoft.EntityFrameworkCore;
using RockWebApp.Models;

namespace RockWebApp.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "John", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Cherry", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Snow", DisplayOrder = 4 }
                );
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
