using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class CCSS_Migration_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "061132f4-b840-493b-ab17-9c8739db8744");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "3f79e7dc-6d64-4ffc-a7e4-9d7ad1f62c3d");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "4de4213c-e890-4988-ac1d-01a188646701");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "6ed2e531-1cb7-4102-8611-ed36719afdcd");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "8397186a-42e3-46e1-930d-10a41cc84725");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "93693b63-6aa3-4d8d-a238-341f2d6c7971");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "9b9322f2-6852-4b7e-9e62-1144c3497b75");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "9fa8a34f-9433-446e-af80-d9da3812f6a5");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "a28ba78a-d5b6-4135-8deb-54b2bfeeaf7a");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "d1d172ce-773d-4601-9af0-e36bb84bb8d9");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e99f9d82-30ac-45d6-a386-4708f61ca899");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "fff876cd-b43a-4185-a2c2-671f5b4a19e4");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "0742e77c-8fc8-4542-8235-d71e712bfe50");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "134028d4-cf1a-41ff-aede-067b62dbcfe3");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "5cd25c21-7b81-497a-b9a4-0eb74e5e2294");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "7db9bb8c-0324-4b91-b644-ce9b12c2ac95");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "865d4421-5df7-41ab-93cf-022fe3b9db23");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "b2408136-c169-4c59-b5b5-bea22495d122");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "b42c6625-4da5-4d31-9ade-279a21385656");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "dbc9ac25-eac8-41b9-a327-0574d7f06e20");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "fa3a03ed-6181-48dc-aaf2-0f41707e81ec");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0267b8e0-ca6c-49ba-bc0d-0f1d4839c66b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0e880aaa-f46c-4bf7-ad73-ebfcd54a4c1b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "10f3237b-c2ce-485a-86c3-79f14e71b9b0");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "12dad848-25db-4562-b9b4-50e16bc14bec");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2452cfc7-dc98-40dc-8279-da0691e9c8e4");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "26eae7ee-3d18-4b33-bb94-0561806942d5");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2844a75a-556e-4e9d-9648-8925d235472e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2b4c8e87-ea32-463e-8f11-62cf4b2d4f12");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2e73065d-0ce3-4809-8b97-bf483bd3d102");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2e82e268-7c51-4af4-91e7-07df7a9fcee1");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "317cbe60-0757-4f96-8521-b07cf0fcd837");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5bd68fe6-e179-435d-9610-8eec9616a3c9");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "625ab3f4-d0f5-41d3-966a-9e31c0315481");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "74024cb1-32dc-453d-91ce-d2fd860cbf1c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "80d7f276-d667-495d-8918-3d07e75c0c1f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "82712e57-a4d6-4fc3-ba46-6801f125989b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "a5f02b5f-86b3-42d1-885b-105eb5043ca4");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "a8e1c928-f3a5-4c30-ae1b-196e2f739ece");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "a9f17915-fa54-4d0f-9c2d-faac39633796");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "aa209192-3de2-4405-8e74-0e598c469938");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "b352637e-30b9-4f59-8971-7395ad47b896");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "b4f562b7-6118-4890-a385-56e2eace7824");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "b5af94e4-30d4-4481-a4d0-cc40306285fe");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "bde6c675-9100-4288-9824-3fdb1577bc8b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "be62eb0c-86f6-4b3f-bfe0-2901dc6f7f9b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "cf8b8ec3-286c-40ae-a721-396883167a93");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e979aac7-79ae-440e-9e6e-5a5994dd003c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f0c9372e-966b-4959-a14a-2985814f91fe");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f73391b0-c275-4436-b03b-196d7d01812b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "fff42b81-1ec5-4d51-88a6-4ea49066adfd");

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4818), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4819) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4824), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4829), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4829) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4832), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4836), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4837) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4840), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4841) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4846), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4846) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4849), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4853), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4857), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4858) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4861), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4866), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4870), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4873), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4874) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4878), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3361), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3362) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3365), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3369), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3373), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3374) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "19852563-f914-4fe2-9f5e-2a1d4e4e3e6f", "C002", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4978), 25000.0, "P005", 3 },
                    { "1d7d3601-fe85-4fbc-a63a-84967c022667", "C004", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5042), 120000.0, "P010", 1 },
                    { "3930c0ca-1675-4663-9a56-6554223bc7e2", "C004", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5047), 35000.0, "P011", 2 },
                    { "41ae1219-0406-4959-861a-68662f9c2388", "C002", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4972), 100000.0, "P004", 1 },
                    { "6c963811-d5be-4394-999b-daa88cfb1319", "C003", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5022), 15000.0, "P007", 5 },
                    { "90c1035e-d428-47e8-9e34-acb9c7b5654d", "C001", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4959), 20000.0, "P002", 1 },
                    { "9d0d68c5-4119-45fe-9ed0-d95eee7ba187", "C003", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5030), 50000.0, "P008", 2 },
                    { "b16789d5-5ada-49f6-a62b-82a5932b8c5e", "C001", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4965), 80000.0, "P003", 1 },
                    { "be6505f0-a90b-42bd-a734-ff5d447cf68f", "C002", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5016), 40000.0, "P006", 2 },
                    { "c577811b-66af-4170-95ff-d1e913ad3eb0", "C001", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4953), 30000.0, "P001", 2 },
                    { "d7da6fae-bcb6-451f-b4d6-5174c6ad0aa6", "C003", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5036), 60000.0, "P009", 1 },
                    { "e3ccf644-9ddc-44d4-b3b9-e23cbdfe4ef9", "C004", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5056), 45000.0, "P012", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                columns: new[] { "CreateDate", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1619), 180f, 80f, 160f, 60f });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                columns: new[] { "CreateDate", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1629), 180f, 80f, 160f, 60f });

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2044));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5267));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5272));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5277));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5338));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5342));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "01c0c32e-2167-42d7-be29-3b1b42a96bf5", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", 5, null },
                    { "05ea6c50-9aca-44da-a5ff-879533ec05cb", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", 5, null },
                    { "06c30585-196f-42d5-846a-dfdadf902d8f", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", 5, null },
                    { "6180e779-c163-4697-94cc-e760f56824fc", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", 5, null },
                    { "6631cc46-460a-4b75-ab20-df2a9a1588e5", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", 5, null },
                    { "79758efa-d675-4444-a438-6a3be57a57a1", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", 5, null },
                    { "abbf2078-2bce-49e3-96da-6470d58375fa", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", 5, null },
                    { "b543317e-9b22-4738-a7bc-ca55366e55bf", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", 5, null },
                    { "e2150dcf-9602-4d40-b52c-51a1e60d899d", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", 5, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(3279));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0350cac5-9bb8-4f53-8894-18454f7ba46b", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5493), "O010", 100000.0, "P004", 1 },
                    { "062bef73-b04e-4eb0-9d19-129f7bcbe5c0", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5427), "O003", 40000.0, "P006", 3 },
                    { "0c67554c-63fd-4427-86d3-3cbef8039a21", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5453), "O006", 35000.0, "P011", 2 },
                    { "1c2d53a1-ebf9-40ec-bab8-bf91835e2bf5", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5474), "O008", 22000.0, "P015", 4 },
                    { "1f7959a4-a0d8-4852-8a69-45a8ffa2119e", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5479), "O008", 30000.0, "P001", 1 },
                    { "1ff90ea6-b5a9-4119-9da8-a67abda96c66", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5402), "O001", 30000.0, "P001", 3 },
                    { "218c9ca8-8cd1-4f21-bf20-37c832d0c10e", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5419), "O002", 100000.0, "P004", 1 },
                    { "297380d0-7c2b-4df6-981d-484bf37880ca", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5626), "O015", 90000.0, "P014", 2 },
                    { "2c81cef1-5d5b-4f83-a0c8-b3bc074f2cf6", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5467), "O007", 90000.0, "P014", 2 },
                    { "2fa24f40-ff6d-4945-bbff-eb1c07945014", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5531), "O013", 35000.0, "P011", 2 },
                    { "33b6c6ca-568b-4237-9991-806834ed9c4a", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5632), "O015", 22000.0, "P015", 4 },
                    { "40c50471-6322-4e96-b427-fe8f614422ba", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5487), "O009", 80000.0, "P003", 2 },
                    { "41640a60-fb5f-4c5f-a088-9e55b6dc284b", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5407), "O001", 20000.0, "P002", 5 },
                    { "467187d6-9969-43af-9840-e150aa86926e", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5506), "O011", 15000.0, "P007", 4 },
                    { "4e7b5b4a-4a1c-428d-9b15-4a9e2c18265d", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5423), "O003", 25000.0, "P005", 2 },
                    { "5197116b-2c44-4d9c-81ba-9047d975708b", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5618), "O014", 18000.0, "P013", 5 },
                    { "5a77fb12-2234-437c-89d5-c80505f1ac99", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5612), "O014", 45000.0, "P012", 3 },
                    { "5ee13e34-67c0-4e5e-be82-2f4dceba0343", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5457), "O006", 45000.0, "P012", 3 },
                    { "5fbb0747-021c-4f47-ab07-78fd2e287740", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5447), "O005", 120000.0, "P010", 1 },
                    { "6d3a7bf7-7c38-476c-af53-7db953dc39ca", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5463), "O007", 18000.0, "P013", 5 },
                    { "763d5fd7-a647-444a-9ea0-f4e81546f77b", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5442), "O005", 60000.0, "P009", 1 },
                    { "802eb9d1-ecfe-4cfa-8530-2d0173962575", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5512), "O012", 50000.0, "P008", 2 },
                    { "8bef6e0c-8831-4135-bb4b-834abc8cf959", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5502), "O011", 40000.0, "P006", 2 },
                    { "9bd6c5c4-0306-4f02-8f16-56f37c9516d8", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5518), "O012", 60000.0, "P009", 1 },
                    { "a7bfc33b-d94f-4dc8-8661-6a7ab589d89f", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5438), "O004", 50000.0, "P008", 2 },
                    { "ada24a6a-3da5-4402-b063-eb608de2c80a", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5434), "O004", 15000.0, "P007", 4 },
                    { "bbdd1fa6-8444-42c6-8890-28fcf7912b67", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5483), "O009", 20000.0, "P002", 6 },
                    { "e1524bae-7170-4c7f-81e8-215e66ed90a6", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5525), "O013", 120000.0, "P010", 1 },
                    { "e1900102-b6a5-4321-aee3-30f4b2fa2f5b", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5414), "O002", 80000.0, "P003", 1 },
                    { "ee2431a8-87d6-4a8e-91fd-99f8a6faa92e", new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5497), "O010", 25000.0, "P005", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R001",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R002",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R003",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R004",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3489));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R005",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R006",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R007",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3506));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R008",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R009",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R010",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R011",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R012",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R013",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3546));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R014",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R015",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6382), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6383) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6391), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6392) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6402), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6402) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6407), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6408) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6413), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6413) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6423), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6424) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6428), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6429) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6435), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6444), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6445) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6450), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6451) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6458), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6459) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6464), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6465) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6470), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6475), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6476) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6481), new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 53, 51, 734, DateTimeKind.Utc).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3696), new DateTime(2025, 4, 29, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3694), new DateTime(2025, 4, 28, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3686), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3697) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3710), new DateTime(2025, 5, 1, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3709), new DateTime(2025, 4, 30, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3708), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3711) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3719), new DateTime(2025, 5, 3, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3717), new DateTime(2025, 5, 2, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3716), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3719) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3732), new DateTime(2025, 4, 27, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3725), new DateTime(2025, 4, 27, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3724), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3755), new DateTime(2025, 5, 5, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3754), new DateTime(2025, 5, 4, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3753), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3756) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3763), new DateTime(2025, 5, 7, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3762), new DateTime(2025, 5, 6, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3761), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3771), new DateTime(2025, 5, 9, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3770), new DateTime(2025, 5, 8, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3768), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3772) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3779), new DateTime(2025, 5, 11, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3777), new DateTime(2025, 5, 10, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3776), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3779) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3786), new DateTime(2025, 5, 13, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3785), new DateTime(2025, 5, 12, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3784), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3797), new DateTime(2025, 5, 15, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3796), new DateTime(2025, 5, 14, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3795), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3798) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3804), new DateTime(2025, 5, 17, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3803), new DateTime(2025, 5, 16, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3802), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3805) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3813), new DateTime(2025, 5, 19, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3812), new DateTime(2025, 5, 18, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3811), new DateTime(2025, 4, 26, 11, 53, 51, 734, DateTimeKind.Local).AddTicks(3814) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "19852563-f914-4fe2-9f5e-2a1d4e4e3e6f");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "1d7d3601-fe85-4fbc-a63a-84967c022667");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "3930c0ca-1675-4663-9a56-6554223bc7e2");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "41ae1219-0406-4959-861a-68662f9c2388");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "6c963811-d5be-4394-999b-daa88cfb1319");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "90c1035e-d428-47e8-9e34-acb9c7b5654d");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "9d0d68c5-4119-45fe-9ed0-d95eee7ba187");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "b16789d5-5ada-49f6-a62b-82a5932b8c5e");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "be6505f0-a90b-42bd-a734-ff5d447cf68f");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "c577811b-66af-4170-95ff-d1e913ad3eb0");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "d7da6fae-bcb6-451f-b4d6-5174c6ad0aa6");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e3ccf644-9ddc-44d4-b3b9-e23cbdfe4ef9");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "01c0c32e-2167-42d7-be29-3b1b42a96bf5");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "05ea6c50-9aca-44da-a5ff-879533ec05cb");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "06c30585-196f-42d5-846a-dfdadf902d8f");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "6180e779-c163-4697-94cc-e760f56824fc");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "6631cc46-460a-4b75-ab20-df2a9a1588e5");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "79758efa-d675-4444-a438-6a3be57a57a1");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "abbf2078-2bce-49e3-96da-6470d58375fa");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "b543317e-9b22-4738-a7bc-ca55366e55bf");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "e2150dcf-9602-4d40-b52c-51a1e60d899d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0350cac5-9bb8-4f53-8894-18454f7ba46b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "062bef73-b04e-4eb0-9d19-129f7bcbe5c0");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0c67554c-63fd-4427-86d3-3cbef8039a21");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1c2d53a1-ebf9-40ec-bab8-bf91835e2bf5");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1f7959a4-a0d8-4852-8a69-45a8ffa2119e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1ff90ea6-b5a9-4119-9da8-a67abda96c66");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "218c9ca8-8cd1-4f21-bf20-37c832d0c10e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "297380d0-7c2b-4df6-981d-484bf37880ca");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2c81cef1-5d5b-4f83-a0c8-b3bc074f2cf6");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2fa24f40-ff6d-4945-bbff-eb1c07945014");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "33b6c6ca-568b-4237-9991-806834ed9c4a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "40c50471-6322-4e96-b427-fe8f614422ba");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "41640a60-fb5f-4c5f-a088-9e55b6dc284b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "467187d6-9969-43af-9840-e150aa86926e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "4e7b5b4a-4a1c-428d-9b15-4a9e2c18265d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5197116b-2c44-4d9c-81ba-9047d975708b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5a77fb12-2234-437c-89d5-c80505f1ac99");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5ee13e34-67c0-4e5e-be82-2f4dceba0343");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5fbb0747-021c-4f47-ab07-78fd2e287740");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "6d3a7bf7-7c38-476c-af53-7db953dc39ca");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "763d5fd7-a647-444a-9ea0-f4e81546f77b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "802eb9d1-ecfe-4cfa-8530-2d0173962575");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "8bef6e0c-8831-4135-bb4b-834abc8cf959");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "9bd6c5c4-0306-4f02-8f16-56f37c9516d8");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "a7bfc33b-d94f-4dc8-8661-6a7ab589d89f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ada24a6a-3da5-4402-b063-eb608de2c80a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "bbdd1fa6-8444-42c6-8890-28fcf7912b67");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e1524bae-7170-4c7f-81e8-215e66ed90a6");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e1900102-b6a5-4321-aee3-30f4b2fa2f5b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ee2431a8-87d6-4a8e-91fd-99f8a6faa92e");

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2306), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2307) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2310), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2312) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2315), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2316) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2319), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2319) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2322), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2325), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2326) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2328), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2329) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2332), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2332) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2338), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2338) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2341), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2342) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2344), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2345) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2347), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2348) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2351), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2351) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2354), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2354) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2357), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2358) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1095), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1095) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1099), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1099) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1101), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1102) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1105), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1107) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "061132f4-b840-493b-ab17-9c8739db8744", "C003", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2481), 50000.0, "P008", 2 },
                    { "3f79e7dc-6d64-4ffc-a7e4-9d7ad1f62c3d", "C004", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2496), 35000.0, "P011", 2 },
                    { "4de4213c-e890-4988-ac1d-01a188646701", "C002", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2472), 40000.0, "P006", 2 },
                    { "6ed2e531-1cb7-4102-8611-ed36719afdcd", "C002", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2461), 100000.0, "P004", 1 },
                    { "8397186a-42e3-46e1-930d-10a41cc84725", "C002", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2468), 25000.0, "P005", 3 },
                    { "93693b63-6aa3-4d8d-a238-341f2d6c7971", "C001", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2408), 30000.0, "P001", 2 },
                    { "9b9322f2-6852-4b7e-9e62-1144c3497b75", "C001", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2416), 20000.0, "P002", 1 },
                    { "9fa8a34f-9433-446e-af80-d9da3812f6a5", "C001", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2420), 80000.0, "P003", 1 },
                    { "a28ba78a-d5b6-4135-8deb-54b2bfeeaf7a", "C003", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2487), 60000.0, "P009", 1 },
                    { "d1d172ce-773d-4601-9af0-e36bb84bb8d9", "C004", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2500), 45000.0, "P012", 1 },
                    { "e99f9d82-30ac-45d6-a386-4708f61ca899", "C003", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2477), 15000.0, "P007", 5 },
                    { "fff876cd-b43a-4185-a2c2-671f5b4a19e4", "C004", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2492), 120000.0, "P010", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 706, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 706, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                columns: new[] { "CreateDate", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(66), 50f, 20f, 30f, 10f });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                columns: new[] { "CreateDate", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(71), 60f, 25f, 40f, 15f });

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "0742e77c-8fc8-4542-8235-d71e712bfe50", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", 5, null },
                    { "134028d4-cf1a-41ff-aede-067b62dbcfe3", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", 5, null },
                    { "5cd25c21-7b81-497a-b9a4-0eb74e5e2294", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", 5, null },
                    { "7db9bb8c-0324-4b91-b644-ce9b12c2ac95", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", 5, null },
                    { "865d4421-5df7-41ab-93cf-022fe3b9db23", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", 5, null },
                    { "b2408136-c169-4c59-b5b5-bea22495d122", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", 5, null },
                    { "b42c6625-4da5-4d31-9ade-279a21385656", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", 5, null },
                    { "dbc9ac25-eac8-41b9-a327-0574d7f06e20", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", 5, null },
                    { "fa3a03ed-6181-48dc-aaf2-0f41707e81ec", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", 5, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(968));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(971));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1046));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(1049));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0267b8e0-ca6c-49ba-bc0d-0f1d4839c66b", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2798), "O009", 80000.0, "P003", 2 },
                    { "0e880aaa-f46c-4bf7-ad73-ebfcd54a4c1b", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2877), "O014", 18000.0, "P013", 5 },
                    { "10f3237b-c2ce-485a-86c3-79f14e71b9b0", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2831), "O013", 35000.0, "P011", 2 },
                    { "12dad848-25db-4562-b9b4-50e16bc14bec", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2881), "O015", 90000.0, "P014", 2 },
                    { "2452cfc7-dc98-40dc-8279-da0691e9c8e4", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2813), "O011", 15000.0, "P007", 4 },
                    { "26eae7ee-3d18-4b33-bb94-0561806942d5", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2802), "O010", 100000.0, "P004", 1 },
                    { "2844a75a-556e-4e9d-9648-8925d235472e", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2810), "O011", 40000.0, "P006", 2 },
                    { "2b4c8e87-ea32-463e-8f11-62cf4b2d4f12", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2791), "O008", 30000.0, "P001", 1 },
                    { "2e73065d-0ce3-4809-8b97-bf483bd3d102", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2751), "O003", 40000.0, "P006", 3 },
                    { "2e82e268-7c51-4af4-91e7-07df7a9fcee1", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2744), "O002", 100000.0, "P004", 1 },
                    { "317cbe60-0757-4f96-8521-b07cf0fcd837", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2824), "O012", 60000.0, "P009", 1 },
                    { "5bd68fe6-e179-435d-9610-8eec9616a3c9", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2807), "O010", 25000.0, "P005", 3 },
                    { "625ab3f4-d0f5-41d3-966a-9e31c0315481", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2739), "O002", 80000.0, "P003", 1 },
                    { "74024cb1-32dc-453d-91ce-d2fd860cbf1c", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2760), "O004", 50000.0, "P008", 2 },
                    { "80d7f276-d667-495d-8918-3d07e75c0c1f", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2818), "O012", 50000.0, "P008", 2 },
                    { "82712e57-a4d6-4fc3-ba46-6801f125989b", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2754), "O004", 15000.0, "P007", 4 },
                    { "a5f02b5f-86b3-42d1-885b-105eb5043ca4", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2748), "O003", 25000.0, "P005", 2 },
                    { "a8e1c928-f3a5-4c30-ae1b-196e2f739ece", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2827), "O013", 120000.0, "P010", 1 },
                    { "a9f17915-fa54-4d0f-9c2d-faac39633796", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2794), "O009", 20000.0, "P002", 6 },
                    { "aa209192-3de2-4405-8e74-0e598c469938", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2885), "O015", 22000.0, "P015", 4 },
                    { "b352637e-30b9-4f59-8971-7395ad47b896", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2731), "O001", 30000.0, "P001", 3 },
                    { "b4f562b7-6118-4890-a385-56e2eace7824", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2782), "O007", 90000.0, "P014", 2 },
                    { "b5af94e4-30d4-4481-a4d0-cc40306285fe", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2871), "O014", 45000.0, "P012", 3 },
                    { "bde6c675-9100-4288-9824-3fdb1577bc8b", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2785), "O008", 22000.0, "P015", 4 },
                    { "be62eb0c-86f6-4b3f-bfe0-2901dc6f7f9b", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2775), "O006", 45000.0, "P012", 3 },
                    { "cf8b8ec3-286c-40ae-a721-396883167a93", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2770), "O006", 35000.0, "P011", 2 },
                    { "e979aac7-79ae-440e-9e6e-5a5994dd003c", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2763), "O005", 60000.0, "P009", 1 },
                    { "f0c9372e-966b-4959-a14a-2985814f91fe", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2735), "O001", 20000.0, "P002", 5 },
                    { "f73391b0-c275-4436-b03b-196d7d01812b", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2778), "O007", 18000.0, "P013", 5 },
                    { "fff42b81-1ec5-4d51-88a6-4ea49066adfd", new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(2766), "O005", 120000.0, "P010", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3044));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R001",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R002",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R003",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R004",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R005",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R006",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R007",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R008",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R009",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R010",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R011",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R012",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R013",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R014",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R015",
                column: "CreatedDate",
                value: new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3150), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3155), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3159), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3163), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3164) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3169), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3228), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3228) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3232), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3232) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3284), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3285) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3288), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3292), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3293) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3296), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3296) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3300), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3306), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3307) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3310), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3314), new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(3315) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 26, 4, 51, 29, 707, DateTimeKind.Utc).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1316), new DateTime(2025, 4, 29, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1315), new DateTime(2025, 4, 28, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1307), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1317) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1325), new DateTime(2025, 5, 1, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1324), new DateTime(2025, 4, 30, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1323), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1326) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1331), new DateTime(2025, 5, 3, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1330), new DateTime(2025, 5, 2, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1330), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1332) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1339), new DateTime(2025, 4, 27, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1339), new DateTime(2025, 4, 27, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1338), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1346), new DateTime(2025, 5, 5, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1345), new DateTime(2025, 5, 4, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1344), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1353), new DateTime(2025, 5, 7, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1352), new DateTime(2025, 5, 6, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1350), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1353) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1359), new DateTime(2025, 5, 9, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1358), new DateTime(2025, 5, 8, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1357), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1365), new DateTime(2025, 5, 11, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1364), new DateTime(2025, 5, 10, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1363), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1366) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1371), new DateTime(2025, 5, 13, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1370), new DateTime(2025, 5, 12, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1369), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1371) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1377), new DateTime(2025, 5, 15, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1377), new DateTime(2025, 5, 14, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1375), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1378) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1384), new DateTime(2025, 5, 17, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1383), new DateTime(2025, 5, 16, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1382), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1384) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1391), new DateTime(2025, 5, 19, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1391), new DateTime(2025, 5, 18, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1390), new DateTime(2025, 4, 26, 11, 51, 29, 707, DateTimeKind.Local).AddTicks(1392) });
        }
    }
}
