using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Identity_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "123456789", 0, "3d396f0d-8040-428c-b359-5570fa4714f7", "Omar Ahmad", "omar@aah.com", true, false, null, "OMAR@AAH.COM", "OMAR@AAH.COM", "AQAAAAIAAYagAAAAECaorPzWJEKZhK7VIxEOCtMPU4Ok7wW/uxcPwrxjCXjU2u17rQryBm8d6++KrK+47w==", "1234567890", true, "8f416c35-b343-4b69-9e02-f2f5e79bc954", false, "omar@aah.com" });

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
