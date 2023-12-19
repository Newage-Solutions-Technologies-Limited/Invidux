using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invidux_Data.Migrations
{
    /// <inheritdoc />
    public partial class OtpAttemptCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OtpAttemptCount",
                table: "SecurityTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "IdCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "InvestmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "KycLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "KycStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "PropertyClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5212));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78115c5e-9eea-41e1-8d9c-70633a360e9b", "36a1373d-1c9f-481b-b971-b6ba4d07eb37", "AppRole", "Partner", "PARTNER" },
                    { "809d165d-c31f-424f-819f-0910d9a1263f", "35b97b98-d2a9-4456-be76-d30711376ade", "AppRole", "Admin", "ADMIN" },
                    { "c3c775fd-2b62-4b80-ac60-eb085e67e74c", "d464bdd5-8ade-4c61-bfb9-e567bc19e3d9", "AppRole", "Investor", "INVESTOR" },
                    { "c407ab6f-920e-4783-ac4f-513830be3b26", "47a1ac32-b21d-4c89-a2df-3de18bb6f914", "AppRole", "Token Issuer", "TOKEN ISSUER" },
                    { "c638f6e0-f9ba-4411-9f71-18e7f8c81e00", "24a6baf2-0eda-49fe-acc0-510c0710bd09", "AppRole", "Dealer/Broker", "DEALER/BROKER" }
                });

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "SecurityTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "TokenListingStatuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "TokenTransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "TwoFactorCovers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "TwoFactorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5616));

            migrationBuilder.InsertData(
                table: "SubRoles",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { "00aa0796-392b-4c93-b283-98d1512be86b", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5336), "Customer Support", "809d165d-c31f-424f-819f-0910d9a1263f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "312c1225-eebc-475a-a434-1e06f73e8524", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5331), "Super Admin", "809d165d-c31f-424f-819f-0910d9a1263f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4af3c68a-989d-4b5a-80f9-9b08ac96d2b8", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5365), "Custodian", "78115c5e-9eea-41e1-8d9c-70633a360e9b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4d2fa5d6-0c4a-44e1-974b-61dcc1030879", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5360), "Token Issuer", "c407ab6f-920e-4783-ac4f-513830be3b26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "653322ea-6f2e-4ac0-ab30-081f0c799138", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5353), "Institutional", "c3c775fd-2b62-4b80-ac60-eb085e67e74c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "676f9486-29e0-4684-8eca-4cb80679eb13", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5356), "Retail", "c3c775fd-2b62-4b80-ac60-eb085e67e74c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8b6373ff-eb97-4fb9-bcd4-b1bce6b67b7d", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5368), "Property Manager", "78115c5e-9eea-41e1-8d9c-70633a360e9b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ad6fbfbe-2f86-4f7e-a8ab-34d75918416a", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5340), "Broker", "c638f6e0-f9ba-4411-9f71-18e7f8c81e00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "b8098802-a2bd-4839-b4c0-ecc02e201534", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5350), "Accrediated", "c3c775fd-2b62-4b80-ac60-eb085e67e74c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "db36db52-5dd8-41b6-815d-e93bdc5c9993", new DateTime(2023, 12, 19, 4, 10, 22, 65, DateTimeKind.Utc).AddTicks(5343), "Dealer", "c638f6e0-f9ba-4411-9f71-18e7f8c81e00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "00aa0796-392b-4c93-b283-98d1512be86b");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "312c1225-eebc-475a-a434-1e06f73e8524");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "4af3c68a-989d-4b5a-80f9-9b08ac96d2b8");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "4d2fa5d6-0c4a-44e1-974b-61dcc1030879");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "653322ea-6f2e-4ac0-ab30-081f0c799138");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "676f9486-29e0-4684-8eca-4cb80679eb13");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "8b6373ff-eb97-4fb9-bcd4-b1bce6b67b7d");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "ad6fbfbe-2f86-4f7e-a8ab-34d75918416a");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "b8098802-a2bd-4839-b4c0-ecc02e201534");

            migrationBuilder.DeleteData(
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: "db36db52-5dd8-41b6-815d-e93bdc5c9993");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "78115c5e-9eea-41e1-8d9c-70633a360e9b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "809d165d-c31f-424f-819f-0910d9a1263f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c3c775fd-2b62-4b80-ac60-eb085e67e74c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c407ab6f-920e-4783-ac4f-513830be3b26");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c638f6e0-f9ba-4411-9f71-18e7f8c81e00");

            migrationBuilder.DropColumn(
                name: "OtpAttemptCount",
                table: "SecurityTokens");

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
    }
}
