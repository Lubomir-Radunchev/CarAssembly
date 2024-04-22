using CarAssembly.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarAssembly.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //// seed!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Seed categories
            //Category[] categories =
            //{
            //     new Category { Name = "Engine Bay" },
            //     new Category { Name = "Interior" }
            //};

            //// Add categories to the DbSet
            //builder.Entity<Category>().HasData(categories);

            //// Call base method
            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        public DbSet<ShowCar> ShowCars { get; set; }
    }
}
