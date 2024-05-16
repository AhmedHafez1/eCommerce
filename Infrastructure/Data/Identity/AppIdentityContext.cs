using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Identity
{
    public class AppIdentityContext : IdentityDbContext<AppUser>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = "123456789",
                UserName = "omar@aah.com",
                NormalizedUserName = "OMAR@AAH.COM",
                Email = "omar@aah.com",
                NormalizedEmail = "OMAR@AAH.COM",
                PhoneNumber = "1234567890",
                DisplayName = "Omar Ahmad",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password123!")
            });

            builder.Entity<Address>().HasData(new Address
            {
                Id = 1,
                Street = "St. 123",
                Country = "Egypt",
                AppUserId = "123456789",
                City = "Giza",
                Building = "17",

            });

            base.OnModelCreating(builder);
        }
    }
}
