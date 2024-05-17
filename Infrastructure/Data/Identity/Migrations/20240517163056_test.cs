using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcce495a-987d-458f-be94-c9865a47a985", "AQAAAAIAAYagAAAAEJy/XoQPWSuWOnooagiTh9ZfFD+3J0GQAcyhKMos14wD6aSlqpMulbF4LQgTsPqAmg==", "dd096881-d318-47a0-8a62-3f1eeea27db0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d396f0d-8040-428c-b359-5570fa4714f7", "AQAAAAIAAYagAAAAECaorPzWJEKZhK7VIxEOCtMPU4Ok7wW/uxcPwrxjCXjU2u17rQryBm8d6++KrK+47w==", "8f416c35-b343-4b69-9e02-f2f5e79bc954" });
        }
    }
}
