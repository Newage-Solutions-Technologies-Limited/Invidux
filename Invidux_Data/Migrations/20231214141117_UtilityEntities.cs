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
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5498), true, "Driver License", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5500), true, "International Passport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5502), false, "NIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5504), false, "Voter's Card", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "InvestmentTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5434), "Long Co-own", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5439), "Medium Co-own", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5440), "Debt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5442), "Co-build", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5443), "Rental", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "KycLevels",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5557), "Level1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5559), "Level2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5561), "Level3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "KycStatuses",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5598), "Pending", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5600), "Verified", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5602), "Restricted", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5650), "Wallet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5652), "Card", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5653), "Bank Transfer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5655), "KongaPay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PropertyClasses",
                columns: new[] { "Id", "Class", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Pre-purchased", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5696), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Wait-listed", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5698), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Off-plan", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5700), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Rented", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5702), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Mortgage-Like", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Under Management", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c6cc33c-cf35-47d6-8a13-79c1b73868bf", "5c3c731a-e982-45a9-9b41-24a785654f8d", "AppRole", "Investor", "INVESTOR" },
                    { "6e654576-9cf8-4e97-b9a4-afe5fbea1c12", "187cf8d5-e51e-4e41-9a65-a97a2d4fb3e7", "AppRole", "Partner", "PARTNER" },
                    { "b477340c-df8b-424c-9510-30077070cba8", "5439b558-5a94-4cbd-9f30-2d9d5d026b87", "AppRole", "Dealer/Broker", "DEALER/BROKER" },
                    { "fab52b5a-00b4-4490-be30-a08e52ff891c", "76285944-5d58-458b-90be-b0fad51d3420", "AppRole", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "SecurityTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5751), "User Registration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5753), "Two Factor Activation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5755), "Two Factor Verification", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5757), "BVN Verification", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TokenListingStatuses",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5953), "Pre-Selling", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5955), "Selling", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5957), "Fully Sold", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5959), "Trading", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5960), "Exited", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TokenTransactionTypes",
                columns: new[] { "Id", "CreatedAt", "TransactionType", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6005), "Buy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6008), "Sell", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6010), "Transfer-in", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6011), "Transfer-out", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6013), "Exited", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6055), "Deposit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6057), "Withdrawal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6059), "Token Earnings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6061), "Referal Earnings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6062), "Tranfer-in", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6064), "Transfer-out", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6066), "Payment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6116), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6118), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6120), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TwoFactorTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6191), "Email", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6194), "Google Auth", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "0a75fb50-2e06-4921-aa0c-c786484e98c9", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5843), "Retail", "6c6cc33c-cf35-47d6-8a13-79c1b73868bf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "24bd24c9-58e8-4507-b690-44e9480dae14", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5831), "Dealer", "b477340c-df8b-424c-9510-30077070cba8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "47bafc49-3995-4043-b408-12a7e56cc6b3", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5839), "Institutional", "6c6cc33c-cf35-47d6-8a13-79c1b73868bf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6864191c-b5ac-42ea-9bfa-56c559c09637", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5835), "Accrediated", "6c6cc33c-cf35-47d6-8a13-79c1b73868bf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "69c2f3bf-450d-4c06-bdf1-b5dc84f08f35", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5895), "Custodian", "6e654576-9cf8-4e97-b9a4-afe5fbea1c12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "7dae3069-da46-45ba-8ef5-0b7e37e45859", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5807), "Super Admin", "fab52b5a-00b4-4490-be30-a08e52ff891c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8e39a4ae-f929-45b3-8036-ab4eb14ff8c1", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5816), "Customer Support", "fab52b5a-00b4-4490-be30-a08e52ff891c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "a4a3de8e-2048-48d5-a0e3-575d2450b1fb", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5827), "Broker", "b477340c-df8b-424c-9510-30077070cba8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c6eeaeac-1dc9-47ba-af8c-d0cf5de9c328", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5900), "Property Manager", "6e654576-9cf8-4e97-b9a4-afe5fbea1c12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                keyValue: "6c6cc33c-cf35-47d6-8a13-79c1b73868bf");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6e654576-9cf8-4e97-b9a4-afe5fbea1c12");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b477340c-df8b-424c-9510-30077070cba8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fab52b5a-00b4-4490-be30-a08e52ff891c");

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
