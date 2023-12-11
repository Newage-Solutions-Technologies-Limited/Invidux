using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class AppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3a5c4ddb-6607-447c-96e1-59af82638980");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4218d329-357c-4d6f-83c7-e545de3faa9a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8616a19c-3683-4676-a153-3f9ff964acd6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e65ad563-d2b2-4ccd-bd20-17ee0696b3dd");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47deaeca-77bf-412e-85f5-9b77808e5825", null, "Investor", "INVESTOR" },
                    { "a882e8fc-8250-4ed8-85d6-27b46dfeab5a", null, "Issuer", "ISSUER" },
                    { "cc6ad11d-df28-45a7-a48c-2aadc9f5cab7", null, "Admin", "ADMIN" },
                    { "db49713e-cc53-4fbc-be33-1002e2ad1541", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "47deaeca-77bf-412e-85f5-9b77808e5825");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a882e8fc-8250-4ed8-85d6-27b46dfeab5a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cc6ad11d-df28-45a7-a48c-2aadc9f5cab7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "db49713e-cc53-4fbc-be33-1002e2ad1541");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a5c4ddb-6607-447c-96e1-59af82638980", null, "Admin", "ADMIN" },
                    { "4218d329-357c-4d6f-83c7-e545de3faa9a", null, "Investor", "INVESTOR" },
                    { "8616a19c-3683-4676-a153-3f9ff964acd6", null, "SuperAdmin", "SUPERADMIN" },
                    { "e65ad563-d2b2-4ccd-bd20-17ee0696b3dd", null, "Issuer", "ISSUER" }
                });
        }
    }
}
