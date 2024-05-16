using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "123456789", 0, "61a3e66c-ef51-4654-a2d2-52d151c7e301", "Omar Ahmad", "omar@aah.com", true, false, null, "OMAR@AAH.COM", "OMAR@AAH.COM", "AQAAAAIAAYagAAAAEH1i2TUqzZrUNiZqO4X9dElWwW9Cmij3ZYfKhzC6Aa7iQRZQBioKVTvptfDHt8KxRQ==", "1234567890", true, "6c98c631-841a-451d-b823-57cdc5fc768f", false, "omar@aah.com" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AppUserId", "Building", "City", "Country", "PostalCode", "Street" },
                values: new object[] { 1, "123456789", "17", "Giza", "Egypt", null, "St. 123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123456789");
        }
    }
}
