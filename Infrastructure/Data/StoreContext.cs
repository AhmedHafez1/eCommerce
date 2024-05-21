using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

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
            var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(
                File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json")
                );

            modelBuilder.Entity<Product>().HasData(products!);
            modelBuilder.Entity<ProductBrand>().HasData(brands!);
            modelBuilder.Entity<ProductType>().HasData(types!);
            modelBuilder.Entity<DeliveryMethod>().HasData(deliveryMethods!);

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties()
                         .Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }


                }
            }

            modelBuilder.Entity<Order>().ComplexProperty(o => o.ShipToAddress);
            modelBuilder.Entity<Order>().Property(o => o.Status)
                .HasConversion(e => e.ToString(), s => (OrderStatus)Enum.Parse(typeof(OrderStatus), s));

            modelBuilder.Entity<OrderItem>().ComplexProperty(oi => oi.ProductItem);
        }
    }
}
