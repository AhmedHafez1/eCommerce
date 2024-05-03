using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var products = JsonSerializer.Deserialize<List<Product>>(
                File.ReadAllText("../Infrastructure/Data/SeedData/products.json")
                );
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(
                File.ReadAllText("../Infrastructure/Data/SeedData/brands.json")
                );
            var types = JsonSerializer.Deserialize<List<ProductType>>(
                File.ReadAllText("../Infrastructure/Data/SeedData/types.json")
                );

            modelBuilder.Entity<Product>().HasData(products!);
            modelBuilder.Entity<ProductBrand>().HasData(brands!);
            modelBuilder.Entity<ProductType>().HasData(types!);
        }
    }
}
