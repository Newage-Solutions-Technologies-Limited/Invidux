using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBVN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "DepositStellarId",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BVN",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1505));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cc99aa5-f9fc-4540-8fc7-702eb32ffd2e", "34b977fa-280e-4eb9-b6ab-7fb40045aaea", "AppRole", "Admin", "ADMIN" },
                    { "729d5f20-fed6-4943-b112-beb448204f99", "7555724e-035e-43b9-93c6-761d36313c40", "AppRole", "Token Issuer", "TOKEN ISSUER" },
                    { "753f5409-74df-455c-9561-fc41917b0c31", "22861eb1-132e-493d-aca8-4fac69a27468", "AppRole", "Dealer/Broker", "DEALER/BROKER" },
                    { "c1eed1bc-7dcf-4cfc-bd3b-30b31a54cd12", "dcb4051e-f5dd-4f7f-8874-18f888dab78f", "AppRole", "Investor", "INVESTOR" },
                    { "f568c526-bdd3-4eb9-934b-f018b2fe9500", "2c5fb6a5-5bdd-4327-8f9f-3f14b594cb4c", "AppRole", "Partner", "PARTNER" }
                });

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1781));

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "3e9dde8e-ec49-4212-8697-11cb6eb0edd1", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1599), "Super Admin", "3cc99aa5-f9fc-4540-8fc7-702eb32ffd2e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4071a09d-a505-45b7-9647-b38b4e98b300", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1606), "Broker", "753f5409-74df-455c-9561-fc41917b0c31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "885a4565-6b93-44dd-8557-ef0225de681b", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1603), "Customer Support", "3cc99aa5-f9fc-4540-8fc7-702eb32ffd2e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8fade1cf-22c3-42cc-afc4-9674a1fe5309", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1623), "Custodian", "f568c526-bdd3-4eb9-934b-f018b2fe9500", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "a2ce471a-5516-4f15-b726-e117507c4944", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1615), "Retail", "c1eed1bc-7dcf-4cfc-bd3b-30b31a54cd12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "be54a738-bc43-4ced-9f87-38236447c4fc", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1608), "Dealer", "753f5409-74df-455c-9561-fc41917b0c31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ca5d256b-3beb-45da-ba75-a58f41603e7a", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1625), "Property Manager", "f568c526-bdd3-4eb9-934b-f018b2fe9500", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d14821cf-e408-4a89-bac7-e814cdf9c2b1", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1620), "Token Issuer", "729d5f20-fed6-4943-b112-beb448204f99", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "de94727e-e0c1-4d51-8b3e-e6bdf9f716bd", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1613), "Institutional", "c1eed1bc-7dcf-4cfc-bd3b-30b31a54cd12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ec82f530-87fd-4e0d-b7c2-766648b43013", new DateTime(2023, 12, 17, 19, 5, 28, 406, DateTimeKind.Utc).AddTicks(1610), "Accrediated", "c1eed1bc-7dcf-4cfc-bd3b-30b31a54cd12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "3e9dde8e-ec49-4212-8697-11cb6eb0edd1");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "4071a09d-a505-45b7-9647-b38b4e98b300");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "885a4565-6b93-44dd-8557-ef0225de681b");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "8fade1cf-22c3-42cc-afc4-9674a1fe5309");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "a2ce471a-5516-4f15-b726-e117507c4944");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "be54a738-bc43-4ced-9f87-38236447c4fc");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "ca5d256b-3beb-45da-ba75-a58f41603e7a");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "d14821cf-e408-4a89-bac7-e814cdf9c2b1");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "de94727e-e0c1-4d51-8b3e-e6bdf9f716bd");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "ec82f530-87fd-4e0d-b7c2-766648b43013");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3cc99aa5-f9fc-4540-8fc7-702eb32ffd2e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "729d5f20-fed6-4943-b112-beb448204f99");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "753f5409-74df-455c-9561-fc41917b0c31");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c1eed1bc-7dcf-4cfc-bd3b-30b31a54cd12");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f568c526-bdd3-4eb9-934b-f018b2fe9500");

            migrationBuilder.AlterColumn<string>(
                name: "DepositStellarId",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BVN",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
