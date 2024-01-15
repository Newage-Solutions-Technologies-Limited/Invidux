using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class LatestPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokenAnnualYield_Token_TokenId",
                table: "TokenAnnualYield");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenApproval_Token_TokenId",
                table: "TokenApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenImage_Token_TokenId",
                table: "TokenImage");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenPresell_Token_TokenId",
                table: "TokenPresell");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Token_TokenId",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokenImage",
                table: "TokenImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokenApproval",
                table: "TokenApproval");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokenAnnualYield",
                table: "TokenAnnualYield");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "01787612-3259-4479-baed-d08bee8cda77");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "0fb6b778-2f7e-49f1-84fa-1def0c12932f");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "4f17088a-c546-4248-82af-77b1250f5e58");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "683c90fb-0446-4af2-9029-176a8c9c936c");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "68db8e32-b141-40b4-81a6-0d4cc6e8a906");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "75f522d9-ec50-4632-bdb2-ea487c4d9ed1");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "7673cbc8-c0e3-4b11-9faf-3ad0c5f30185");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "89a1924c-77a0-42c1-bcad-ea6df3dbc19c");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "8def1d5e-427c-4e92-a1e3-4280a8477655");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "e10c911a-208f-46b3-ae77-2dd408b936da");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2b8fb2fb-df83-486e-8b1e-fdbea1233270");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "64891cb0-a4b6-477c-b1e2-9b72852a9977");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d27c78aa-bfe6-4132-8376-2664bb436378");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "eb2cfd2a-6b80-4455-94ad-c6b10d109602");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ff71bb50-78f7-49cc-8e97-8c676dd4b3c4");

            migrationBuilder.RenameTable(
                name: "TokenImage",
                newName: "TokenImages");

            migrationBuilder.RenameTable(
                name: "TokenApproval",
                newName: "TokenApprovals");

            migrationBuilder.RenameTable(
                name: "TokenAnnualYield",
                newName: "TokenAnnualYields");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "Tokens");

            migrationBuilder.RenameIndex(
                name: "IX_TokenImage_TokenId",
                table: "TokenImages",
                newName: "IX_TokenImages_TokenId");

            migrationBuilder.RenameIndex(
                name: "IX_TokenApproval_TokenId",
                table: "TokenApprovals",
                newName: "IX_TokenApprovals_TokenId");

            migrationBuilder.RenameIndex(
                name: "IX_TokenAnnualYield_TokenId",
                table: "TokenAnnualYields",
                newName: "IX_TokenAnnualYields_TokenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokenImages",
                table: "TokenImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokenApprovals",
                table: "TokenApprovals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokenAnnualYields",
                table: "TokenAnnualYields",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1719));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "171686e7-50ca-4011-b129-f2dd76c44220", "2ea456f5-8e95-49e8-84a6-1152da71d72f", "AppRole", "Investor", "INVESTOR" },
                    { "9b87b9da-427c-4284-beaa-75582ea5ba62", "915f49c3-a160-44ea-b004-dbdadca8684d", "AppRole", "Admin", "ADMIN" },
                    { "a9535f62-2c13-4128-80e0-131a062ae415", "243971e6-6313-48d8-8370-9e9bc1acc8ff", "AppRole", "Dealer/Broker", "DEALER/BROKER" },
                    { "d5c79f56-e815-419d-ba9d-7d67237c4fdf", "c922967f-e96c-4e1f-a104-b3038a9afe17", "AppRole", "Token Issuer", "TOKEN ISSUER" },
                    { "e3dc3541-50b9-46fd-9435-61691651f03f", "c8ef87f0-1108-4f77-8d3e-aa13e2d965b0", "AppRole", "Partner", "PARTNER" }
                });

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(2028));

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "0d6387cb-2570-4e28-a7b3-21e1b9b8e4de", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1852), "Retail", "171686e7-50ca-4011-b129-f2dd76c44220", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2ad20396-41fb-41af-935f-04cf842dd1e4", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1861), "Custodian", "e3dc3541-50b9-46fd-9435-61691651f03f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "51469b04-cfee-421e-be67-7e1e91ed34ea", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1848), "Institutional", "171686e7-50ca-4011-b129-f2dd76c44220", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "54fd19b3-4371-4f46-a3b9-f92938001317", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1787), "Super Admin", "9b87b9da-427c-4284-beaa-75582ea5ba62", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5b207753-ad3f-4d80-9362-631f4ba15238", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1841), "Broker", "a9535f62-2c13-4128-80e0-131a062ae415", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5ef9036a-5410-4a85-bf04-819d4e0a9b4f", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1846), "Accrediated", "171686e7-50ca-4011-b129-f2dd76c44220", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "61d6114e-ad08-456e-89eb-968b69324a25", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1864), "Property Manager", "e3dc3541-50b9-46fd-9435-61691651f03f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "82317758-30a9-4831-9aca-eebd5d54d781", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1837), "Customer Support", "9b87b9da-427c-4284-beaa-75582ea5ba62", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8db4b1e6-6a64-44af-b7a9-3aba708164dc", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1843), "Dealer", "a9535f62-2c13-4128-80e0-131a062ae415", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ec941275-56b5-4724-93e9-6ffa4efd80a7", new DateTime(2024, 1, 12, 17, 28, 46, 744, DateTimeKind.Utc).AddTicks(1859), "Token Issuer", "d5c79f56-e815-419d-ba9d-7d67237c4fdf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TokenAnnualYields_Tokens_TokenId",
                table: "TokenAnnualYields",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenApprovals_Tokens_TokenId",
                table: "TokenApprovals",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenImages_Tokens_TokenId",
                table: "TokenImages",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPresell_Tokens_TokenId",
                table: "TokenPresell",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Tokens_TokenId",
                table: "UserTokens",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokenAnnualYields_Tokens_TokenId",
                table: "TokenAnnualYields");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenApprovals_Tokens_TokenId",
                table: "TokenApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenImages_Tokens_TokenId",
                table: "TokenImages");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenPresell_Tokens_TokenId",
                table: "TokenPresell");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Tokens_TokenId",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokenImages",
                table: "TokenImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokenApprovals",
                table: "TokenApprovals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokenAnnualYields",
                table: "TokenAnnualYields");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "0d6387cb-2570-4e28-a7b3-21e1b9b8e4de");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "2ad20396-41fb-41af-935f-04cf842dd1e4");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "51469b04-cfee-421e-be67-7e1e91ed34ea");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "54fd19b3-4371-4f46-a3b9-f92938001317");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "5b207753-ad3f-4d80-9362-631f4ba15238");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "5ef9036a-5410-4a85-bf04-819d4e0a9b4f");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "61d6114e-ad08-456e-89eb-968b69324a25");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "82317758-30a9-4831-9aca-eebd5d54d781");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "8db4b1e6-6a64-44af-b7a9-3aba708164dc");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "ec941275-56b5-4724-93e9-6ffa4efd80a7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "171686e7-50ca-4011-b129-f2dd76c44220");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9b87b9da-427c-4284-beaa-75582ea5ba62");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a9535f62-2c13-4128-80e0-131a062ae415");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d5c79f56-e815-419d-ba9d-7d67237c4fdf");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e3dc3541-50b9-46fd-9435-61691651f03f");

            migrationBuilder.RenameTable(
                name: "Tokens",
                newName: "Token");

            migrationBuilder.RenameTable(
                name: "TokenImages",
                newName: "TokenImage");

            migrationBuilder.RenameTable(
                name: "TokenApprovals",
                newName: "TokenApproval");

            migrationBuilder.RenameTable(
                name: "TokenAnnualYields",
                newName: "TokenAnnualYield");

            migrationBuilder.RenameIndex(
                name: "IX_TokenImages_TokenId",
                table: "TokenImage",
                newName: "IX_TokenImage_TokenId");

            migrationBuilder.RenameIndex(
                name: "IX_TokenApprovals_TokenId",
                table: "TokenApproval",
                newName: "IX_TokenApproval_TokenId");

            migrationBuilder.RenameIndex(
                name: "IX_TokenAnnualYields_TokenId",
                table: "TokenAnnualYield",
                newName: "IX_TokenAnnualYield_TokenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokenImage",
                table: "TokenImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokenApproval",
                table: "TokenApproval",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokenAnnualYield",
                table: "TokenAnnualYield",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b8fb2fb-df83-486e-8b1e-fdbea1233270", "38b6a007-242b-4f13-8ba4-a0f55bf09d6e", "AppRole", "Investor", "INVESTOR" },
                    { "64891cb0-a4b6-477c-b1e2-9b72852a9977", "d09fcefe-bff0-478c-a1e2-055f154c190f", "AppRole", "Partner", "PARTNER" },
                    { "d27c78aa-bfe6-4132-8376-2664bb436378", "3a94ba5a-ac0e-47e3-9fcf-84e571f68dec", "AppRole", "Admin", "ADMIN" },
                    { "eb2cfd2a-6b80-4455-94ad-c6b10d109602", "721d370c-1130-4ca4-bbb9-d304332522fd", "AppRole", "Token Issuer", "TOKEN ISSUER" },
                    { "ff71bb50-78f7-49cc-8e97-8c676dd4b3c4", "1f9f29d0-934b-464f-aaea-be210d9fb978", "AppRole", "Dealer/Broker", "DEALER/BROKER" }
                });

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(5076));

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "01787612-3259-4479-baed-d08bee8cda77", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4824), "Super Admin", "d27c78aa-bfe6-4132-8376-2664bb436378", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "0fb6b778-2f7e-49f1-84fa-1def0c12932f", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4841), "Institutional", "2b8fb2fb-df83-486e-8b1e-fdbea1233270", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4f17088a-c546-4248-82af-77b1250f5e58", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4832), "Broker", "ff71bb50-78f7-49cc-8e97-8c676dd4b3c4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "683c90fb-0446-4af2-9029-176a8c9c936c", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4835), "Dealer", "ff71bb50-78f7-49cc-8e97-8c676dd4b3c4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "68db8e32-b141-40b4-81a6-0d4cc6e8a906", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4829), "Customer Support", "d27c78aa-bfe6-4132-8376-2664bb436378", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "75f522d9-ec50-4632-bdb2-ea487c4d9ed1", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4852), "Token Issuer", "eb2cfd2a-6b80-4455-94ad-c6b10d109602", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "7673cbc8-c0e3-4b11-9faf-3ad0c5f30185", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4848), "Retail", "2b8fb2fb-df83-486e-8b1e-fdbea1233270", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "89a1924c-77a0-42c1-bcad-ea6df3dbc19c", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4854), "Custodian", "64891cb0-a4b6-477c-b1e2-9b72852a9977", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8def1d5e-427c-4e92-a1e3-4280a8477655", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4838), "Accrediated", "2b8fb2fb-df83-486e-8b1e-fdbea1233270", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "e10c911a-208f-46b3-ae77-2dd408b936da", new DateTime(2024, 1, 11, 13, 48, 7, 329, DateTimeKind.Utc).AddTicks(4858), "Property Manager", "64891cb0-a4b6-477c-b1e2-9b72852a9977", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TokenAnnualYield_Token_TokenId",
                table: "TokenAnnualYield",
                column: "TokenId",
                principalTable: "Token",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenApproval_Token_TokenId",
                table: "TokenApproval",
                column: "TokenId",
                principalTable: "Token",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenImage_Token_TokenId",
                table: "TokenImage",
                column: "TokenId",
                principalTable: "Token",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPresell_Token_TokenId",
                table: "TokenPresell",
                column: "TokenId",
                principalTable: "Token",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Token_TokenId",
                table: "UserTokens",
                column: "TokenId",
                principalTable: "Token",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
