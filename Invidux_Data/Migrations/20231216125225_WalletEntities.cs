using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class WalletEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "0a75fb50-2e06-4921-aa0c-c786484e98c9");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "24bd24c9-58e8-4507-b690-44e9480dae14");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "47bafc49-3995-4043-b408-12a7e56cc6b3");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "6864191c-b5ac-42ea-9bfa-56c559c09637");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "69c2f3bf-450d-4c06-bdf1-b5dc84f08f35");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "7dae3069-da46-45ba-8ef5-0b7e37e45859");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "8e39a4ae-f929-45b3-8036-ab4eb14ff8c1");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "a4a3de8e-2048-48d5-a0e3-575d2450b1fb");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "c6eeaeac-1dc9-47ba-af8c-d0cf5de9c328");

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

            migrationBuilder.AddColumn<bool>(
                name: "PinSet",
                table: "Wallets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "UserKycInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "UserKycInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Inflow",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3402));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3464), "Level2" });

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Class", "CreatedAt" },
                values: new object[] { "Off-plan", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3534) });

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Class", "CreatedAt" },
                values: new object[] { "Pre-purchased", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3535) });

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Class", "CreatedAt" },
                values: new object[] { "Wait-listed", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3536) });

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3538));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f67d11c-d2a8-43bf-bb7c-4344aa5e57de", "b4e00c67-fd98-4e41-9bf5-8ca903db2656", "AppRole", "Dealer/Broker", "DEALER/BROKER" },
                    { "376f3aa5-8b63-43c3-b86c-77487735a323", "9ae6e2b9-a2e5-4974-9660-085d4190e275", "AppRole", "Investor", "INVESTOR" },
                    { "484a69e9-99c2-41c0-9e02-3705da64dc5c", "a0c00598-8e08-4cc7-85c6-a04be019434a", "AppRole", "Token Issuer", "TOKEN ISSUER" },
                    { "68c1e442-983a-498c-b2f2-5fd57fa96863", "152ec2bb-de96-49cc-ab90-b63fb50d8adc", "AppRole", "Admin", "ADMIN" },
                    { "82a44040-28a1-4adc-a581-535f63aeab60", "fd08adea-647e-4762-81ed-b1c98bd15d7f", "AppRole", "Partner", "PARTNER" }
                });

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3637), "Off-Plan" });

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3638), "Wait-listed" });

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3639), "Selling" });

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3639), "Fully Sold" });

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3640), "Trading" });

            migrationBuilder.InsertData(
                table: "TokenListingStatuses",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3642), "Exited", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "1c17b74d-54a7-4b1b-8c65-9a2d8699a59a", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3604), "Institutional", "376f3aa5-8b63-43c3-b86c-77487735a323", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2584c729-2e74-4993-a0a1-8931e0a6b0c7", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3598), "Broker", "2f67d11c-d2a8-43bf-bb7c-4344aa5e57de", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "31ebcba2-648a-4359-bede-2c3d2baf9937", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3589), "Super Admin", "68c1e442-983a-498c-b2f2-5fd57fa96863", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "54a73c69-073e-4dca-a11a-f56317d9655b", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3612), "Property Manager", "82a44040-28a1-4adc-a581-535f63aeab60", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9743a9c5-1c1b-4232-986a-b80b62614d93", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3602), "Accrediated", "376f3aa5-8b63-43c3-b86c-77487735a323", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "b01dc913-4621-4068-9cab-b10fd51cf8b5", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3608), "Token Issuer", "484a69e9-99c2-41c0-9e02-3705da64dc5c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "b2d65d56-b116-417f-ac75-79e878eeab5e", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3606), "Retail", "376f3aa5-8b63-43c3-b86c-77487735a323", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d36907df-db04-4970-aa8a-0d7c0ae60592", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3600), "Dealer", "2f67d11c-d2a8-43bf-bb7c-4344aa5e57de", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "efb5cf03-acfc-4fa1-8c07-a6564b7317d8", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3593), "Customer Support", "68c1e442-983a-498c-b2f2-5fd57fa96863", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "f6900617-edcd-4002-8634-1cd6dc625fe8", new DateTime(2023, 12, 16, 12, 52, 25, 55, DateTimeKind.Utc).AddTicks(3610), "Custodian", "82a44040-28a1-4adc-a581-535f63aeab60", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "1c17b74d-54a7-4b1b-8c65-9a2d8699a59a");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "2584c729-2e74-4993-a0a1-8931e0a6b0c7");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "31ebcba2-648a-4359-bede-2c3d2baf9937");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "54a73c69-073e-4dca-a11a-f56317d9655b");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "9743a9c5-1c1b-4232-986a-b80b62614d93");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "b01dc913-4621-4068-9cab-b10fd51cf8b5");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "b2d65d56-b116-417f-ac75-79e878eeab5e");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "d36907df-db04-4970-aa8a-0d7c0ae60592");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "efb5cf03-acfc-4fa1-8c07-a6564b7317d8");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "f6900617-edcd-4002-8634-1cd6dc625fe8");

            migrationBuilder.DeleteData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2f67d11c-d2a8-43bf-bb7c-4344aa5e57de");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "376f3aa5-8b63-43c3-b86c-77487735a323");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "484a69e9-99c2-41c0-9e02-3705da64dc5c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "68c1e442-983a-498c-b2f2-5fd57fa96863");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "82a44040-28a1-4adc-a581-535f63aeab60");

            migrationBuilder.DropColumn(
                name: "PinSet",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "UserKycInfos");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "UserKycInfos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Inflow",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5559));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5561), "Level3" });

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Class", "CreatedAt" },
                values: new object[] { "Pre-purchased", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5696) });

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Class", "CreatedAt" },
                values: new object[] { "Wait-listed", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5698) });

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Class", "CreatedAt" },
                values: new object[] { "Off-plan", new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5705));

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

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5953), "Pre-Selling" });

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5955), "Selling" });

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5957), "Fully Sold" });

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5959), "Trading" });

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(5960), "Exited" });

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6120));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 14, 14, 11, 15, 596, DateTimeKind.Utc).AddTicks(6194));

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
        }
    }
}
