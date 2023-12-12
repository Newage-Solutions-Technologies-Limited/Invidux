using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuditLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0915e8d9-87d4-491c-977d-f949f02a9fd1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "717e07dc-bc8f-4504-976d-ab46f6c3c913");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c99ffdd2-a422-4d34-aab2-cba5a8176b9d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fd750a78-90f3-406e-b0e1-cf4002cbe0d7");

            migrationBuilder.RenameColumn(
                name: "AdditionalInformation",
                table: "AuditLogs",
                newName: "AffectedColumns");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1276e662-8e7f-4584-afb1-e93057dafcaf", null, "Admin", "ADMIN" },
                    { "1c2bbddc-0cdf-4d35-ab52-950baaeaefb3", null, "SuperAdmin", "SUPERADMIN" },
                    { "4511d276-c021-4704-96fb-884cf54c1dc8", null, "Issuer", "ISSUER" },
                    { "ccb1b40f-837e-4456-a231-279b771433ce", null, "Investor", "INVESTOR" }
                });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 12, 14, 37, 37, 657, DateTimeKind.Utc).AddTicks(9301), new DateTime(2023, 12, 12, 14, 37, 37, 657, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 12, 14, 37, 37, 657, DateTimeKind.Utc).AddTicks(9306), new DateTime(2023, 12, 12, 14, 37, 37, 657, DateTimeKind.Utc).AddTicks(9307) });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 12, 14, 37, 37, 657, DateTimeKind.Utc).AddTicks(9308), new DateTime(2023, 12, 12, 14, 37, 37, 657, DateTimeKind.Utc).AddTicks(9308) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1276e662-8e7f-4584-afb1-e93057dafcaf");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1c2bbddc-0cdf-4d35-ab52-950baaeaefb3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4511d276-c021-4704-96fb-884cf54c1dc8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ccb1b40f-837e-4456-a231-279b771433ce");

            migrationBuilder.RenameColumn(
                name: "AffectedColumns",
                table: "AuditLogs",
                newName: "AdditionalInformation");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0915e8d9-87d4-491c-977d-f949f02a9fd1", null, "Investor", "INVESTOR" },
                    { "717e07dc-bc8f-4504-976d-ab46f6c3c913", null, "SuperAdmin", "SUPERADMIN" },
                    { "c99ffdd2-a422-4d34-aab2-cba5a8176b9d", null, "Admin", "ADMIN" },
                    { "fd750a78-90f3-406e-b0e1-cf4002cbe0d7", null, "Issuer", "ISSUER" }
                });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1642), new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1647), new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1647) });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1648), new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1648) });
        }
    }
}
