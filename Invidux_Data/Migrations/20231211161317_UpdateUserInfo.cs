using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "TwoFactorCover",
                table: "Users",
                newName: "TwoFactorType");

            migrationBuilder.RenameColumn(
                name: "InvestmentLimit",
                table: "UserIncomeInfos",
                newName: "InvestmentLimitUsed");

            migrationBuilder.AlterColumn<string>(
                name: "Relationship",
                table: "UserNextOfKins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserNextOfKins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserNextOfKins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserNextOfKins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "UserKycInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdType",
                table: "UserKycInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TwoFactorCovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoFactorCovers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTwoFactorCovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TwoFactorCoverId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTwoFactorCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTwoFactorCovers_TwoFactorCovers_TwoFactorCoverId",
                        column: x => x.TwoFactorCoverId,
                        principalTable: "TwoFactorCovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTwoFactorCovers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "TwoFactorCovers",
                columns: new[] { "Id", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1642), "Login", new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1645) },
                    { 2, new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1647), "Transaction", new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1647) },
                    { 3, new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1648), "Trading", new DateTime(2023, 12, 11, 16, 13, 16, 325, DateTimeKind.Utc).AddTicks(1648) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTwoFactorCovers_TwoFactorCoverId",
                table: "UserTwoFactorCovers",
                column: "TwoFactorCoverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTwoFactorCovers_UserId",
                table: "UserTwoFactorCovers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTwoFactorCovers");

            migrationBuilder.DropTable(
                name: "TwoFactorCovers");

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
                name: "TwoFactorType",
                table: "Users",
                newName: "TwoFactorCover");

            migrationBuilder.RenameColumn(
                name: "InvestmentLimitUsed",
                table: "UserIncomeInfos",
                newName: "InvestmentLimit");

            migrationBuilder.AlterColumn<string>(
                name: "Relationship",
                table: "UserNextOfKins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserNextOfKins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserNextOfKins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserNextOfKins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "UserKycInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdType",
                table: "UserKycInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
