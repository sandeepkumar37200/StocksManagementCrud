using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;

namespace Plugins.DataStore.SQL
{
    public class MarketDbContext:DbContext 
    {
        public MarketDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // setuping relationship between Category->propduct(1 category can have many products)
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            //seeding data

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }
             );


            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 20, Price = 30 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 10, Price = 60 },
                new Product { ProductId = 3, CategoryId = 2, Name = "Brown Bread", Quantity = 20, Price = 40 },
                new Product { ProductId = 4, CategoryId = 1, Name = "Cake", Quantity = 20, Price = 40 }
            );
        }
    }
}
