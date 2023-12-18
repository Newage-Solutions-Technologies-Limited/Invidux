using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class UserToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Users_UserId",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "0c6279ef-e595-49c6-8ff3-9f6a393f432a");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "25a7bf04-4cf8-4914-808c-698dee2ccd7a");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "4664d9ba-9a62-4a00-8a5b-5a32c0ae34fe");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "6d7da5b0-bf89-4791-a331-1b91d235852c");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "77986fa2-36aa-4950-b0e0-f945dbd1097b");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "90868d99-411e-4293-872a-09e3b655e04e");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "9aede186-5c16-4dc8-95c6-3c5bac1522ee");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "9c0574fd-75bb-4a13-bacd-85f5b01c6670");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "abec80bb-552c-44c6-bf33-23c3e013f288");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "ac151d0b-8a7c-48fa-8174-4aeb8e0738e9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0f4fc1da-b171-48d0-b7fe-b647c68752b7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6a0d58f7-1b24-4bdc-8d27-bd0e6b2b2265");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b0237720-d9ff-4277-90f0-04fb7c36ba8d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c3bee9c7-75b0-455f-8f3c-27d44e45134a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dfdc6669-a8c1-48b3-a87c-da15ad25da9f");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BankAccounts");

            migrationBuilder.AddColumn<int>(
                name: "TokenId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Earnings = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WalletId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1486));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "256240ec-badc-4a6d-b55d-16354c4b7a26", "6d9e8501-3d95-4fb6-afb5-759ca3722887", "AppRole", "Investor", "INVESTOR" },
                    { "3911687d-5e45-4d75-afd5-48d50abd659f", "2b29e7cb-fcb2-4b00-b5a9-153858fe0029", "AppRole", "Token Issuer", "TOKEN ISSUER" },
                    { "5e4bf039-cff8-4524-b7b2-b1c3f0301625", "7afc9bb3-63b4-4c17-a352-ac2639a916ac", "AppRole", "Partner", "PARTNER" },
                    { "63ee5981-c7cf-4a07-aa76-4ad8511865b8", "b6b15b0d-d8f5-4fd4-8e48-562271a83bdc", "AppRole", "Dealer/Broker", "DEALER/BROKER" },
                    { "f1fa972f-9618-4e1d-98b4-204a818947e7", "1beb740d-88aa-4b06-8b60-e4b1b02eec60", "AppRole", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1903));

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "3f4ede15-9e66-46f5-ae65-272c5a2653c5", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1659), "Broker", "63ee5981-c7cf-4a07-aa76-4ad8511865b8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "47d3b22c-d887-4a76-9b13-c82da9aadc40", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1651), "Super Admin", "f1fa972f-9618-4e1d-98b4-204a818947e7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5009ad46-3db7-4a53-8d84-fbc54a7f7413", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1716), "Property Manager", "5e4bf039-cff8-4524-b7b2-b1c3f0301625", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "72c661c2-297c-4e2e-bad6-347c6d92a521", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1673), "Retail", "256240ec-badc-4a6d-b55d-16354c4b7a26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "87e68980-d41b-49aa-9b92-75cabcfe87e5", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1667), "Institutional", "256240ec-badc-4a6d-b55d-16354c4b7a26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9e674791-3fd4-4381-a4e3-b31f92e50958", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1661), "Dealer", "63ee5981-c7cf-4a07-aa76-4ad8511865b8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "aff5662a-319c-450b-947f-509e271fd7f8", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1714), "Custodian", "5e4bf039-cff8-4524-b7b2-b1c3f0301625", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "e37a447e-26e9-40aa-b681-6321406bdb35", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1711), "Token Issuer", "3911687d-5e45-4d75-afd5-48d50abd659f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "f0c079e5-cacb-4acd-a423-62d202af8a6e", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1664), "Accrediated", "256240ec-badc-4a6d-b55d-16354c4b7a26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "fbb2fdb3-807a-4555-8a99-6e71fb2c598c", new DateTime(2023, 12, 17, 11, 6, 18, 384, DateTimeKind.Utc).AddTicks(1656), "Customer Support", "f1fa972f-9618-4e1d-98b4-204a818947e7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_TokenId",
                table: "BankAccounts",
                column: "TokenId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_WalletId",
                table: "UserTokens",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_UserTokens_TokenId",
                table: "BankAccounts",
                column: "TokenId",
                principalTable: "UserTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_UserTokens_TokenId",
                table: "BankAccounts");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_TokenId",
                table: "BankAccounts");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "3f4ede15-9e66-46f5-ae65-272c5a2653c5");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "47d3b22c-d887-4a76-9b13-c82da9aadc40");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "5009ad46-3db7-4a53-8d84-fbc54a7f7413");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "72c661c2-297c-4e2e-bad6-347c6d92a521");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "87e68980-d41b-49aa-9b92-75cabcfe87e5");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "9e674791-3fd4-4381-a4e3-b31f92e50958");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "aff5662a-319c-450b-947f-509e271fd7f8");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "e37a447e-26e9-40aa-b681-6321406bdb35");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "f0c079e5-cacb-4acd-a423-62d202af8a6e");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "fbb2fdb3-807a-4555-8a99-6e71fb2c598c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "256240ec-badc-4a6d-b55d-16354c4b7a26");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3911687d-5e45-4d75-afd5-48d50abd659f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5e4bf039-cff8-4524-b7b2-b1c3f0301625");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "63ee5981-c7cf-4a07-aa76-4ad8511865b8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f1fa972f-9618-4e1d-98b4-204a818947e7");

            migrationBuilder.DropColumn(
                name: "TokenId",
                table: "BankAccounts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BankAccounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3961));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3962));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f4fc1da-b171-48d0-b7fe-b647c68752b7", "966c2909-6c91-4476-bac4-229b227a2e1b", "AppRole", "Dealer/Broker", "DEALER/BROKER" },
                    { "6a0d58f7-1b24-4bdc-8d27-bd0e6b2b2265", "09b909e4-60f1-49c2-a1ce-c4c2841226c1", "AppRole", "Admin", "ADMIN" },
                    { "b0237720-d9ff-4277-90f0-04fb7c36ba8d", "4e67b396-696e-49d6-bb56-15c9fef0d452", "AppRole", "Token Issuer", "TOKEN ISSUER" },
                    { "c3bee9c7-75b0-455f-8f3c-27d44e45134a", "e59f37f4-3f7b-457b-856c-4c79abf610b4", "AppRole", "Investor", "INVESTOR" },
                    { "dfdc6669-a8c1-48b3-a87c-da15ad25da9f", "b696664d-003d-41a6-a0d4-d2873b901e05", "AppRole", "Partner", "PARTNER" }
                });

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4121));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "0c6279ef-e595-49c6-8ff3-9f6a393f432a", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4076), "Accrediated", "c3bee9c7-75b0-455f-8f3c-27d44e45134a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "25a7bf04-4cf8-4914-808c-698dee2ccd7a", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4088), "Custodian", "dfdc6669-a8c1-48b3-a87c-da15ad25da9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4664d9ba-9a62-4a00-8a5b-5a32c0ae34fe", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4081), "Institutional", "c3bee9c7-75b0-455f-8f3c-27d44e45134a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6d7da5b0-bf89-4791-a331-1b91d235852c", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4083), "Retail", "c3bee9c7-75b0-455f-8f3c-27d44e45134a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "77986fa2-36aa-4950-b0e0-f945dbd1097b", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4070), "Customer Support", "6a0d58f7-1b24-4bdc-8d27-bd0e6b2b2265", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "90868d99-411e-4293-872a-09e3b655e04e", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4072), "Broker", "0f4fc1da-b171-48d0-b7fe-b647c68752b7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9aede186-5c16-4dc8-95c6-3c5bac1522ee", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4074), "Dealer", "0f4fc1da-b171-48d0-b7fe-b647c68752b7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9c0574fd-75bb-4a13-bacd-85f5b01c6670", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4090), "Property Manager", "dfdc6669-a8c1-48b3-a87c-da15ad25da9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "abec80bb-552c-44c6-bf33-23c3e013f288", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4066), "Super Admin", "6a0d58f7-1b24-4bdc-8d27-bd0e6b2b2265", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ac151d0b-8a7c-48fa-8174-4aeb8e0738e9", new DateTime(2023, 12, 17, 8, 58, 4, 101, DateTimeKind.Utc).AddTicks(4085), "Token Issuer", "b0237720-d9ff-4277-90f0-04fb7c36ba8d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Users_UserId",
                table: "BankAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
