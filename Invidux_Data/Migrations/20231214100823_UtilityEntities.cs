using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class UtilityEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "VerificationTokens");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "UserKycInfos");

            migrationBuilder.DropColumn(
                name: "Flow",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ImagePublicId",
                table: "UserInformation",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TwoFactorCovers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "TransactionRef",
                table: "Transactions",
                newName: "InternalRef");

            migrationBuilder.AddColumn<string>(
                name: "SecurityType",
                table: "VerificationTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TwoFactorType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationStatus",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "UserKycInfos",
                type: "nvarchar(max)",
                nullable: true,
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

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserKycInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Sender",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ExternalRef",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Roles",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IdCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KycLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KycLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KycStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KycStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokenListingStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenListingStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenTransactionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenTransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TwoFactorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoFactorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSubRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubRoles_SubRoles_SubRoleId",
                        column: x => x.SubRoleId,
                        principalTable: "SubRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdCards",
                columns: new[] { "Id", "CreatedAt", "Expires", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7661), true, "Driver License", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7664), true, "International Passport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7666), false, "NIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7668), false, "Voter's Card", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "InvestmentTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7568), "Long Co-own", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7575), "Medium Co-own", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7577), "Debt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7581), "Co-build", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7583), "Rental", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "KycLevels",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7718), "Level1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7721), "Level2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7726), "Level3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "KycStatuses",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7772), "Pending", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7776), "Verified", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7778), "Restricted", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7841), "Wallet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7843), "Card", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7844), "Bank Transfer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7846), "KongaPay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PropertyClasses",
                columns: new[] { "Id", "Class", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Pre-purchased", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7943), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Wait-listed", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7946), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Off-plan", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7948), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Rented", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7949), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Mortgage-Like", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7951), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Under Management", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(7953), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19473d89-c5ad-4c22-a199-d52a237ae6c2", "f8249e03-8815-4c7b-a80a-4e2ca00118ae", "IdentityRole", "Admin", "ADMIN" },
                    { "58d7427f-b62f-4198-8031-cb7ca9ebef52", "8c3b16e6-0a1e-4b13-8f3c-45fd9512c449", "IdentityRole", "Dealer/Broker", "DEALER/BROKER" },
                    { "a703401b-6f4d-4200-8ada-79039d00816e", "6a6abf79-824d-4f9b-9e5a-41d18dc01666", "IdentityRole", "Investor", "INVESTOR" },
                    { "aad92f6a-fe61-466c-bfed-a693491914dc", "1b443371-438b-40f2-b98b-2203f2208417", "IdentityRole", "Partner", "PARTNER" }
                });

            migrationBuilder.InsertData(
                table: "SecurityTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8003), "User Registration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8005), "Two Factor Activation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8007), "Two Factor Verification", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8009), "BVN Verification", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TokenListingStatuses",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8174), "Pre-Selling", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8175), "Selling", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8177), "Fully Sold", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8178), "Trading", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8180), "Exited", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TokenTransactionTypes",
                columns: new[] { "Id", "CreatedAt", "TransactionType", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8229), "Buy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8231), "Sell", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8233), "Transfer-in", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8234), "Transfer-out", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8235), "Exited", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8285), "Deposit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8287), "Withdrawal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8289), "Token Earnings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8291), "Referal Earnings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8292), "Tranfer-in", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8294), "Transfer-out", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8295), "Payment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8353), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8355), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TwoFactorTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8399), "Email", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8401), "Google Auth", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "0114770a-ca8d-4235-963f-55c756e8f4ea", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8108), "Retail", "a703401b-6f4d-4200-8ada-79039d00816e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3e4ad38e-7d46-42f2-98fd-45e5191081cf", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8092), "Accrediated", "a703401b-6f4d-4200-8ada-79039d00816e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "45fd0bcc-6649-4c4b-9c72-20b84e2204e7", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8112), "Custodian", "aad92f6a-fe61-466c-bfed-a693491914dc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4e3c0e3b-ae44-4084-9c20-4be6df4d8bb2", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8087), "Dealer", "58d7427f-b62f-4198-8031-cb7ca9ebef52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "68575913-5e79-4025-bb57-f57b5f4f346a", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8096), "Institutional", "a703401b-6f4d-4200-8ada-79039d00816e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6eedb0ee-e7f8-49fe-a4d0-9aa442a36d1a", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8073), "Super Admin", "19473d89-c5ad-4c22-a199-d52a237ae6c2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "7f70be47-96aa-4576-a3ec-9b31569dfd1b", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8079), "Customer Support", "19473d89-c5ad-4c22-a199-d52a237ae6c2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9e3b04ac-6270-4af3-a547-5dbaf11393ba", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8116), "Property Manager", "aad92f6a-fe61-466c-bfed-a693491914dc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "b364a3ee-3526-4eb6-a747-e11e8766f65f", new DateTime(2023, 12, 14, 10, 8, 20, 400, DateTimeKind.Utc).AddTicks(8083), "Broker", "58d7427f-b62f-4198-8031-cb7ca9ebef52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubRoles_RoleId",
                table: "SubRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubRoles_SubRoleId",
                table: "UserSubRoles",
                column: "SubRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdCards");

            migrationBuilder.DropTable(
                name: "InvestmentTypes");

            migrationBuilder.DropTable(
                name: "KycLevels");

            migrationBuilder.DropTable(
                name: "KycStatuses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PropertyClasses");

            migrationBuilder.DropTable(
                name: "SecurityTypes");

            migrationBuilder.DropTable(
                name: "TokenListingStatuses");

            migrationBuilder.DropTable(
                name: "TokenTransactionTypes");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "TwoFactorTypes");

            migrationBuilder.DropTable(
                name: "UserSubRoles");

            migrationBuilder.DropTable(
                name: "SubRoles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "19473d89-c5ad-4c22-a199-d52a237ae6c2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "58d7427f-b62f-4198-8031-cb7ca9ebef52");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a703401b-6f4d-4200-8ada-79039d00816e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "aad92f6a-fe61-466c-bfed-a693491914dc");

            migrationBuilder.DropColumn(
                name: "SecurityType",
                table: "VerificationTokens");

            migrationBuilder.DropColumn(
                name: "RegistrationStatus",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserKycInfos");

            migrationBuilder.DropColumn(
                name: "ExternalRef",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "UserInformation",
                newName: "ImagePublicId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "TwoFactorCovers",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "InternalRef",
                table: "Transactions",
                newName: "TransactionRef");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "VerificationTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TwoFactorType",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "UserKycInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdType",
                table: "UserKycInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "UserKycInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sender",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Flow",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
