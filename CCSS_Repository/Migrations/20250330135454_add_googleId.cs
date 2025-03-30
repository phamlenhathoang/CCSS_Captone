using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_googleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "3ce3e2ef-267d-49ec-aa29-5355fd86c6e2");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "678cba65-15df-4717-89f5-8ac63a1f82b4");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "7b1c7e12-2962-4150-a513-dfad1f620b88");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "96f288d5-9dea-4a6e-8421-2a29df40677a");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "a8317668-229d-4ad6-87e9-bcdfd716f336");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "c8b04176-460c-46d6-b220-18f780fbc53d");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "d6e00d96-9881-4970-9a38-24a2d6eb4904");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e11aec7c-7d6a-494c-be6b-a340fa07b39b");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e3b729be-4207-4603-8b78-2d3dbe592a07");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "fe8a4209-c2cc-4e25-8b09-28b9879bceea");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "ff0481db-3c2c-4e91-b196-ac20f246082f");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "ffa2dcff-23e7-45a3-a472-3dbc26f97c3b");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "1337c141-87da-4e66-bee5-e4950d3de422");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "2230bfe7-6174-4e9b-a6dd-d5c519b7d0d4");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "350bcf2e-857b-4197-88ec-b15c32966725");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "462fd686-83b0-4de7-8773-e4c6ff8e6034");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "4b690ec4-9270-43a8-8fac-29228e93b13a");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "774d5a8e-50ab-4287-a402-3019da26f6fb");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "c014219d-44a3-4b38-9134-76db93d6828b");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "e81775f6-cb6f-4403-8c79-bed6437306fe");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "fcbff270-db0b-4bf2-b056-597749ba6093");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0267fee8-089b-4f18-8f84-acf6bb5be0f8");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "056b7308-0f28-49a6-ae67-4f0716480e67");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "13a6a6e7-8167-4e0d-ad20-bf6e97b56711");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "16e2fbef-d760-487b-92a1-140c93e2916a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "23d62cc6-e21e-43e6-97d0-2e7458d809c1");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "25ccb6a1-22ec-45d4-9125-f976adf2ad60");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "263416d3-5ab6-4b6f-9add-9c68af7ff9d4");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "28f12bf6-ac2e-4a0f-a86b-39e24483899f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2dc94bac-85e6-4d51-9a51-ddb1c1297acc");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "3673c47c-2ec7-4231-b30e-00119ee5f333");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "3a153ed5-c082-4220-be90-5fcf0c0f87bf");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "3f3c74c2-ed35-4e91-8d39-51286711da0f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "4e0b0cc4-df06-447c-a3d9-9cfb1e28884f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "54d9640d-c8ac-4608-adcf-8a1cc83eb9da");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "67c9cdfc-5d12-4bee-8ddc-1edddfa18ada");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "6c4d5b9b-198d-4304-a462-96474acf12cb");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "6f7570a9-c381-4100-aefd-723bd72bd172");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "700b8c21-abb6-47f2-b062-0a6cc601a37a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "74b6dfb6-f4b4-4c6d-849b-82b832b685bb");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "82ba8ac1-c354-4373-875f-b5e38d60a82a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "891d77e6-30c8-4e83-b3c8-040fd2d1347d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ada7f95a-43c5-46f6-8487-1a3e1efc8adb");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "b3233cf7-2656-4ee4-adf7-97228c0027e0");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "b855237f-e8d8-4b2c-95d6-78fc16ce80e7");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "bf9987b2-d8c4-4bfc-ba4e-dd04de91a4de");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "c7636a7d-cedd-424f-8127-db9cac711ded");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "c83cdeae-1d2e-4b6f-8f07-3231764ce13b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ede6e417-15e7-481d-bed2-32713741c090");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f44a5e59-931f-4b91-b7e9-1074abb765c9");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f683b005-0069-4fa3-a022-f95ac2e38b9a");

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1307));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1354), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1356) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1359), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1363), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1364) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1366), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1367) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1370), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1371) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1374), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1375) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1380), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1384), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1385) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1456), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1462), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1466), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1466) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1470), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1473), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1477), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1483), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1484) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(283), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(284) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(289), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(292), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(293) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(296), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(296) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "017cc402-3b2d-45e8-874e-d66137ff0198", "C004", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1599), 45.0, "P012", 1 },
                    { "17a406de-efe1-425b-8319-cd086c5a8f7f", "C002", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1566), 40.0, "P006", 2 },
                    { "383a09e9-b91e-45c0-9411-e3ffa6f50b34", "C004", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1592), 35.0, "P011", 2 },
                    { "68d58044-b390-4995-92e1-880a5112ac4d", "C001", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1539), 30.0, "P001", 2 },
                    { "74319d88-c7a5-4c29-8d06-81bae586121d", "C002", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1556), 100.0, "P004", 1 },
                    { "8281ff65-f26c-436c-b04e-7132ef880d8f", "C003", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1578), 50.0, "P008", 2 },
                    { "c8c5c998-be3b-4b8f-9f66-2c936e777563", "C002", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1561), 25.0, "P005", 3 },
                    { "d3059c2a-9d64-492c-acd4-2737586b58e6", "C001", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1549), 80.0, "P003", 1 },
                    { "d73fa40c-aa4f-4b1d-924a-e268f6235491", "C004", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1588), 120.0, "P010", 1 },
                    { "e377fc9e-74e0-4c8d-b361-912a64b6613c", "C003", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1583), 60.0, "P009", 1 },
                    { "ebcf6c16-1bc8-43ac-b86c-9f21db8e2cfc", "C003", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1571), 15.0, "P007", 5 },
                    { "f2535b85-4250-405f-b4e8-eeefba875729", "C001", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1544), 20.0, "P002", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1044));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(996));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1878));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "01c1ed24-81d6-4ef7-8957-23e48357cbf4", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null, null },
                    { "01e8e8aa-6c29-4dd5-9550-0fa781fee3e3", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null, null },
                    { "0333e039-2550-4947-9195-bacca39f4b69", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null, null },
                    { "18dfd4fe-4523-4e3b-b5ef-ee87eeee2754", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null, null },
                    { "21d75686-31b9-4f37-a2f0-30fe810df1f4", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null, null },
                    { "2854dc11-e234-4982-bc5a-eea539df1f3c", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null, null },
                    { "521588e2-be05-446e-bf40-b96df4edb368", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null, null },
                    { "8e1367b0-a768-4a72-950a-d4e26a1f99b5", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null, null },
                    { "e0fbb40b-ff9f-4fcd-aa00-5cf1ec29834b", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(217));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(237));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0637375d-1e9e-46bb-a45c-749727fbdc85", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2119), "O011", 40.0, "P006", 2 },
                    { "088dd97c-aecb-485b-bd3c-2550716d3509", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1983), "O007", 18.0, "P013", 5 },
                    { "0c5edf6e-641a-422a-a62c-8f28c2c4ace3", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2129), "O012", 50.0, "P008", 2 },
                    { "1028a5ca-7f46-4b04-811d-ef40c632d55c", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2159), "O015", 22.0, "P015", 4 },
                    { "15334593-2a34-418c-a67f-e713a491ea01", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2100), "O009", 20.0, "P002", 6 },
                    { "1b64e3eb-00b4-4650-a3ac-406b301d1848", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1933), "O001", 20.0, "P002", 5 },
                    { "1d58fe17-18c9-478b-b156-ecd3977ec725", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2133), "O012", 60.0, "P009", 1 },
                    { "1e31d04d-740b-40f2-87fa-27cf21b31f75", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1926), "O001", 30.0, "P001", 3 },
                    { "25146f0d-caf3-4564-8f66-67ebf8c02cb6", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1957), "O004", 15.0, "P007", 4 },
                    { "2bb4bee5-0d49-45bf-a642-0a07d52c649c", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2147), "O014", 45.0, "P012", 3 },
                    { "2d45ded2-0568-47b8-acd9-63c12d6173cd", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2096), "O008", 30.0, "P001", 1 },
                    { "3d68698e-dd98-48af-a754-5d7c4daba5b6", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2140), "O013", 35.0, "P011", 2 },
                    { "3f122fb3-ad5f-4ee2-a4d0-631224a5e8be", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2151), "O014", 18.0, "P013", 5 },
                    { "48448131-f31b-476f-a528-e1d0e707fcfa", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1975), "O006", 35.0, "P011", 2 },
                    { "4cb380d1-f64d-49f9-bf2c-dc27c4820ef1", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1943), "O002", 100.0, "P004", 1 },
                    { "61c85fe8-9a59-4c34-8350-9c55ad112b60", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1951), "O003", 40.0, "P006", 3 },
                    { "6c265aff-8e90-4207-b4c2-d34ec251fccb", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2123), "O011", 15.0, "P007", 4 },
                    { "75fa03c3-42ef-47a9-afb4-60dc7e71b080", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2136), "O013", 120.0, "P010", 1 },
                    { "89f2847f-0d2e-4951-8b21-02ae6a5dd7ae", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2114), "O010", 25.0, "P005", 3 },
                    { "98e9bcd6-8113-4a7f-b2a2-b2dc7de203ab", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2111), "O010", 100.0, "P004", 1 },
                    { "9b4c5904-80ab-4b99-a11e-aea35d5a87a8", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2154), "O015", 90.0, "P014", 2 },
                    { "a4a5bfa5-7eb6-49b3-b2af-fd0a497ce4e6", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1947), "O003", 25.0, "P005", 2 },
                    { "ac1aea71-d402-4f14-9094-202d5224c23d", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1939), "O002", 80.0, "P003", 1 },
                    { "bdc67680-d766-4e02-8ef6-547284bb19d3", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1979), "O006", 45.0, "P012", 3 },
                    { "d24c70f8-55ca-4dca-8b7f-e35700e7cc7d", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2104), "O009", 80.0, "P003", 2 },
                    { "d3ffc222-6468-4ecd-ba7f-292103b81e09", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1969), "O005", 120.0, "P010", 1 },
                    { "d91531fa-fabd-4997-8720-b47ab3d27f1c", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1965), "O005", 60.0, "P009", 1 },
                    { "df7cdd76-e46e-4498-9b7f-4191974ee901", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(1961), "O004", 50.0, "P008", 2 },
                    { "e385d3f7-d397-4528-b056-8db1cd3b47b4", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2084), "O007", 90.0, "P014", 2 },
                    { "eb6da50a-7cb1-4017-90c8-9122e16900a9", new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2092), "O008", 22.0, "P015", 4 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2436), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2438) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2442), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2443) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2448), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2449) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2452), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2452) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2457), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2478) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2483), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2483) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2486), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2487) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2490), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2491) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2495), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2495) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2499), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2500) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2505), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2509), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2510) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2513), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2516), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2517) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2520), new DateTime(2025, 3, 30, 13, 54, 51, 141, DateTimeKind.Utc).AddTicks(2521) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 13, 54, 51, 140, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(532), new DateTime(2025, 4, 2, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(530), new DateTime(2025, 4, 1, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(513), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(533) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(543), new DateTime(2025, 4, 4, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(542), new DateTime(2025, 4, 3, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(541), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(544) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(550), new DateTime(2025, 4, 6, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(549), new DateTime(2025, 4, 5, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(548), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(556), new DateTime(2025, 3, 31, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(555), new DateTime(2025, 3, 31, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(554), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(556) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(562), new DateTime(2025, 4, 8, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(561), new DateTime(2025, 4, 7, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(560), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(563) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(568), new DateTime(2025, 4, 10, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(567), new DateTime(2025, 4, 9, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(566), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(569) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(574), new DateTime(2025, 4, 12, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(573), new DateTime(2025, 4, 11, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(572), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(575) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(596), new DateTime(2025, 4, 14, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(584), new DateTime(2025, 4, 13, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(578), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(604), new DateTime(2025, 4, 16, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(603), new DateTime(2025, 4, 15, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(602), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(612), new DateTime(2025, 4, 18, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(612), new DateTime(2025, 4, 17, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(611), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(613) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(619), new DateTime(2025, 4, 20, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(618), new DateTime(2025, 4, 19, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(617), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(619) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(669), new DateTime(2025, 4, 22, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(668), new DateTime(2025, 4, 21, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(667), new DateTime(2025, 3, 30, 20, 54, 51, 141, DateTimeKind.Local).AddTicks(670) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "017cc402-3b2d-45e8-874e-d66137ff0198");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "17a406de-efe1-425b-8319-cd086c5a8f7f");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "383a09e9-b91e-45c0-9411-e3ffa6f50b34");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "68d58044-b390-4995-92e1-880a5112ac4d");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "74319d88-c7a5-4c29-8d06-81bae586121d");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "8281ff65-f26c-436c-b04e-7132ef880d8f");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "c8c5c998-be3b-4b8f-9f66-2c936e777563");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "d3059c2a-9d64-492c-acd4-2737586b58e6");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "d73fa40c-aa4f-4b1d-924a-e268f6235491");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e377fc9e-74e0-4c8d-b361-912a64b6613c");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "ebcf6c16-1bc8-43ac-b86c-9f21db8e2cfc");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "f2535b85-4250-405f-b4e8-eeefba875729");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "01c1ed24-81d6-4ef7-8957-23e48357cbf4");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "01e8e8aa-6c29-4dd5-9550-0fa781fee3e3");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "0333e039-2550-4947-9195-bacca39f4b69");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "18dfd4fe-4523-4e3b-b5ef-ee87eeee2754");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "21d75686-31b9-4f37-a2f0-30fe810df1f4");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "2854dc11-e234-4982-bc5a-eea539df1f3c");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "521588e2-be05-446e-bf40-b96df4edb368");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "8e1367b0-a768-4a72-950a-d4e26a1f99b5");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "e0fbb40b-ff9f-4fcd-aa00-5cf1ec29834b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0637375d-1e9e-46bb-a45c-749727fbdc85");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "088dd97c-aecb-485b-bd3c-2550716d3509");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0c5edf6e-641a-422a-a62c-8f28c2c4ace3");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1028a5ca-7f46-4b04-811d-ef40c632d55c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "15334593-2a34-418c-a67f-e713a491ea01");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1b64e3eb-00b4-4650-a3ac-406b301d1848");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1d58fe17-18c9-478b-b156-ecd3977ec725");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1e31d04d-740b-40f2-87fa-27cf21b31f75");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "25146f0d-caf3-4564-8f66-67ebf8c02cb6");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2bb4bee5-0d49-45bf-a642-0a07d52c649c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2d45ded2-0568-47b8-acd9-63c12d6173cd");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "3d68698e-dd98-48af-a754-5d7c4daba5b6");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "3f122fb3-ad5f-4ee2-a4d0-631224a5e8be");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "48448131-f31b-476f-a528-e1d0e707fcfa");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "4cb380d1-f64d-49f9-bf2c-dc27c4820ef1");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "61c85fe8-9a59-4c34-8350-9c55ad112b60");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "6c265aff-8e90-4207-b4c2-d34ec251fccb");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "75fa03c3-42ef-47a9-afb4-60dc7e71b080");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "89f2847f-0d2e-4951-8b21-02ae6a5dd7ae");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "98e9bcd6-8113-4a7f-b2a2-b2dc7de203ab");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "9b4c5904-80ab-4b99-a11e-aea35d5a87a8");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "a4a5bfa5-7eb6-49b3-b2af-fd0a497ce4e6");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ac1aea71-d402-4f14-9094-202d5224c23d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "bdc67680-d766-4e02-8ef6-547284bb19d3");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "d24c70f8-55ca-4dca-8b7f-e35700e7cc7d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "d3ffc222-6468-4ecd-ba7f-292103b81e09");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "d91531fa-fabd-4997-8720-b47ab3d27f1c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "df7cdd76-e46e-4498-9b7f-4191974ee901");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e385d3f7-d397-4528-b056-8db1cd3b47b4");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "eb6da50a-7cb1-4017-90c8-9122e16900a9");

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6475));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6505), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6506) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6508), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6509) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6511), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6511) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6513), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6513) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6515), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6515) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6517), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6517) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6519), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6519) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6553), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6555), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6555) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6557), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6557) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6560), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6562), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6563) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6564), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6565) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6566), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6567) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6569), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6569) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5847), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5850), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5851) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5852), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5853) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5854), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5856) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "3ce3e2ef-267d-49ec-aa29-5355fd86c6e2", "C004", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6647), 45.0, "P012", 1 },
                    { "678cba65-15df-4717-89f5-8ac63a1f82b4", "C001", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6615), 80.0, "P003", 1 },
                    { "7b1c7e12-2962-4150-a513-dfad1f620b88", "C002", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6623), 25.0, "P005", 3 },
                    { "96f288d5-9dea-4a6e-8421-2a29df40677a", "C003", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6637), 60.0, "P009", 1 },
                    { "a8317668-229d-4ad6-87e9-bcdfd716f336", "C004", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6643), 35.0, "P011", 2 },
                    { "c8b04176-460c-46d6-b220-18f780fbc53d", "C002", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6619), 100.0, "P004", 1 },
                    { "d6e00d96-9881-4970-9a38-24a2d6eb4904", "C001", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6612), 20.0, "P002", 1 },
                    { "e11aec7c-7d6a-494c-be6b-a340fa07b39b", "C003", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6629), 15.0, "P007", 5 },
                    { "e3b729be-4207-4603-8b78-2d3dbe592a07", "C001", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6609), 30.0, "P001", 2 },
                    { "fe8a4209-c2cc-4e25-8b09-28b9879bceea", "C003", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6632), 50.0, "P008", 2 },
                    { "ff0481db-3c2c-4e91-b196-ac20f246082f", "C002", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6626), 40.0, "P006", 2 },
                    { "ffa2dcff-23e7-45a3-a472-3dbc26f97c3b", "C004", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6640), 120.0, "P010", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "1337c141-87da-4e66-bee5-e4950d3de422", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null, null },
                    { "2230bfe7-6174-4e9b-a6dd-d5c519b7d0d4", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null, null },
                    { "350bcf2e-857b-4197-88ec-b15c32966725", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null, null },
                    { "462fd686-83b0-4de7-8773-e4c6ff8e6034", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null, null },
                    { "4b690ec4-9270-43a8-8fac-29228e93b13a", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null, null },
                    { "774d5a8e-50ab-4287-a402-3019da26f6fb", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null, null },
                    { "c014219d-44a3-4b38-9134-76db93d6828b", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null, null },
                    { "e81775f6-cb6f-4403-8c79-bed6437306fe", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null, null },
                    { "fcbff270-db0b-4bf2-b056-597749ba6093", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5804));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0267fee8-089b-4f18-8f84-acf6bb5be0f8", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6898), "O011", 40.0, "P006", 2 },
                    { "056b7308-0f28-49a6-ae67-4f0716480e67", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6889), "O010", 100.0, "P004", 1 },
                    { "13a6a6e7-8167-4e0d-ad20-bf6e97b56711", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6832), "O004", 15.0, "P007", 4 },
                    { "16e2fbef-d760-487b-92a1-140c93e2916a", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6826), "O003", 25.0, "P005", 2 },
                    { "23d62cc6-e21e-43e6-97d0-2e7458d809c1", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6901), "O011", 15.0, "P007", 4 },
                    { "25ccb6a1-22ec-45d4-9125-f976adf2ad60", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6828), "O003", 40.0, "P006", 3 },
                    { "263416d3-5ab6-4b6f-9add-9c68af7ff9d4", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6814), "O001", 30.0, "P001", 3 },
                    { "28f12bf6-ac2e-4a0f-a86b-39e24483899f", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6883), "O009", 20.0, "P002", 6 },
                    { "2dc94bac-85e6-4d51-9a51-ddb1c1297acc", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6920), "O015", 90.0, "P014", 2 },
                    { "3673c47c-2ec7-4231-b30e-00119ee5f333", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6911), "O013", 35.0, "P011", 2 },
                    { "3a153ed5-c082-4220-be90-5fcf0c0f87bf", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6923), "O015", 22.0, "P015", 4 },
                    { "3f3c74c2-ed35-4e91-8d39-51286711da0f", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6835), "O004", 50.0, "P008", 2 },
                    { "4e0b0cc4-df06-447c-a3d9-9cfb1e28884f", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6873), "O007", 90.0, "P014", 2 },
                    { "54d9640d-c8ac-4608-adcf-8a1cc83eb9da", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6885), "O009", 80.0, "P003", 2 },
                    { "67c9cdfc-5d12-4bee-8ddc-1edddfa18ada", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6846), "O006", 45.0, "P012", 3 },
                    { "6c4d5b9b-198d-4304-a462-96474acf12cb", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6844), "O006", 35.0, "P011", 2 },
                    { "6f7570a9-c381-4100-aefd-723bd72bd172", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6918), "O014", 18.0, "P013", 5 },
                    { "700b8c21-abb6-47f2-b062-0a6cc601a37a", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6891), "O010", 25.0, "P005", 3 },
                    { "74b6dfb6-f4b4-4c6d-849b-82b832b685bb", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6880), "O008", 30.0, "P001", 1 },
                    { "82ba8ac1-c354-4373-875f-b5e38d60a82a", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6838), "O005", 60.0, "P009", 1 },
                    { "891d77e6-30c8-4e83-b3c8-040fd2d1347d", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6823), "O002", 100.0, "P004", 1 },
                    { "ada7f95a-43c5-46f6-8487-1a3e1efc8adb", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6915), "O014", 45.0, "P012", 3 },
                    { "b3233cf7-2656-4ee4-adf7-97228c0027e0", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6821), "O002", 80.0, "P003", 1 },
                    { "b855237f-e8d8-4b2c-95d6-78fc16ce80e7", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6817), "O001", 20.0, "P002", 5 },
                    { "bf9987b2-d8c4-4bfc-ba4e-dd04de91a4de", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6840), "O005", 120.0, "P010", 1 },
                    { "c7636a7d-cedd-424f-8127-db9cac711ded", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6907), "O012", 60.0, "P009", 1 },
                    { "c83cdeae-1d2e-4b6f-8f07-3231764ce13b", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6904), "O012", 50.0, "P008", 2 },
                    { "ede6e417-15e7-481d-bed2-32713741c090", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6909), "O013", 120.0, "P010", 1 },
                    { "f44a5e59-931f-4b91-b7e9-1074abb765c9", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6877), "O008", 22.0, "P015", 4 },
                    { "f683b005-0069-4fa3-a022-f95ac2e38b9a", new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(6848), "O007", 18.0, "P013", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5254));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7080), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7081) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7084), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7084) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7087), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7087) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7091), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7091) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7093), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7094) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7096), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7096) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7098), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7099) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7101), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7101) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7103), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7104) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7106), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7106) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7108), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7109) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7112), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7113) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7115), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7115) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7117), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7117) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7119), new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5156));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 28, 14, 3, 58, 568, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6004), new DateTime(2025, 3, 31, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6002), new DateTime(2025, 3, 30, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(5988), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6004) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6009), new DateTime(2025, 4, 2, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6008), new DateTime(2025, 4, 1, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6008), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6015), new DateTime(2025, 4, 4, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6014), new DateTime(2025, 4, 3, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6013), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6015) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6020), new DateTime(2025, 3, 29, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6019), new DateTime(2025, 3, 29, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6018), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6023), new DateTime(2025, 4, 6, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6023), new DateTime(2025, 4, 5, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6022), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6028), new DateTime(2025, 4, 8, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6027), new DateTime(2025, 4, 7, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6026), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6028) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6033), new DateTime(2025, 4, 10, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6032), new DateTime(2025, 4, 9, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6031), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6037), new DateTime(2025, 4, 12, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6036), new DateTime(2025, 4, 11, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6035), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6037) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6042), new DateTime(2025, 4, 14, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6041), new DateTime(2025, 4, 13, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6040), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6042) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6046), new DateTime(2025, 4, 16, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6045), new DateTime(2025, 4, 15, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6044), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6046) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6051), new DateTime(2025, 4, 18, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6051), new DateTime(2025, 4, 17, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6050), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6052) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6100), new DateTime(2025, 4, 20, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6099), new DateTime(2025, 4, 19, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6099), new DateTime(2025, 3, 28, 21, 3, 58, 568, DateTimeKind.Local).AddTicks(6100) });
        }
    }
}
