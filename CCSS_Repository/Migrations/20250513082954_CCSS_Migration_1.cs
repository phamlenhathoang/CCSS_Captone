using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class CCSS_Migration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "09f62286-6500-4b80-9364-77dedc6f3205");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "32cdcf59-c0ef-4b9d-949d-0518f34ebad3");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "41074a7d-6c85-4596-8399-57c4f2eb9894");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "59ee64be-963d-44c5-bf7c-b4d7b5f4c328");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "7743132a-9010-4a3e-a770-2f7a03840aad");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "8a17b85e-964d-404f-a35d-c2d5d05bf995");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "b23f4087-b4ba-49bc-a137-e17d318af514");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "c3f57a76-f030-4451-bee8-7c8f4a278d97");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "c4a75511-3f99-4504-9fff-350282dd099a");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "da05f98d-86a9-4c17-bf47-7af37421c7a7");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e02f9d7f-ba3d-4243-9b2f-c4b1da944fc2");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "f3cc8e42-5726-43d2-8783-526e04c5517d");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "0c13d1f2-5869-45ec-a7a6-48cad80e8848");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "1442f63b-4e28-409a-a32f-dfdbd29b5d6f");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "32f32682-b63d-4cce-8908-b609092d4e67");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "57ae6f17-607f-47d6-9bf2-36bdf8b6f2cc");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "725a0272-16d4-40b9-bbe9-f20ea2d23e95");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "88874e03-033a-40fa-a654-cc415449b5c5");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "a9d96248-6598-4ec2-a6bc-8f9da65a15f8");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "ef456794-7f4b-4f89-a8bd-b9d44c8d3979");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "f808599f-58b0-49b7-a552-8e6928808d52");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "07500a2f-2c1a-4abd-b20d-42e27efbc008");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "088d4ed4-5601-4a51-a55a-c8adc503769f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0d676fc2-ed13-40c6-a435-969aa4b6fc78");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "11cc2e4f-1b1b-4850-8180-a54f2df4ed2c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2ef0411c-b628-4cf5-bafb-05b9198d9a8f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "3370f374-0b9c-4904-97fe-a336ab749812");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "399d272c-493e-4680-84dd-0a8c4558075d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "422ee7ca-7ffe-4d7d-bbbc-e91376c65a97");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "4dd380a2-0fef-4b9a-b3ed-f10e62a4ca24");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5198e180-04db-45f7-98ad-07b16d6c45bc");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "52a42dbf-3062-4794-8b28-f52cd44584d5");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "54700c81-0208-42df-aafa-76111951abe4");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5f88668b-7598-4aa0-ba23-f342ee4ea4ec");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "690cbf95-1c15-42ee-a5b1-74b697d447bf");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "84ef3f89-0d66-469a-b7fb-299cf213dbde");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "851c6bef-dc3d-4fe1-83f2-69341ca46817");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "9115e935-c3b6-4a88-abf2-decaff6998ab");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "99830c16-ba9e-4870-8b89-cbe920fc7b8d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "a8a7236d-ad76-4d84-942f-23141991b406");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ad79decf-2258-4c45-b441-2727606d0005");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ad8ab8d0-8264-4c8a-a54d-e5ea5a300d4d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e10368c5-52db-4c4d-aa1f-2294dc0fc8e5");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e1cfd85e-3f3b-4588-b3d0-03d4cb42d05c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e4b312f1-5158-47f8-9fdd-fc029c1ad1e0");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e5b1fe26-de7e-476a-abab-57acfd8ea05c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e642fb38-fc04-49d4-925f-f6af6875c956");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e6a8f699-4712-4535-b477-031236ea4852");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ecb32d17-4893-4595-9f33-960175cf5d04");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f372e35d-5741-4358-ba52-2825eadc386a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f8718435-0dd6-49db-9244-fd0327dee0cd");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "ContractImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(971));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1061), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1064), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1064) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1066), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1067) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1068), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1070), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1073), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1075), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1077), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1080), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1081) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1082), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1083) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1084), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1085) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1087), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1087) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1089), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1089) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1091), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1091) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1093), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(330), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(331) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(334), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(334) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(336), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(336) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(338), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(338) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0b4aeceb-05bd-46c2-99a8-adc5771e5dea", "C002", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1141), 25000.0, "P005", 3 },
                    { "1d04b17b-3d43-41d4-aaf4-27e2d5dfd5bd", "C001", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1131), 20000.0, "P002", 1 },
                    { "29620272-3b8c-4cc0-a8d9-239ee037e62b", "C002", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1136), 100000.0, "P004", 1 },
                    { "2fa4e09e-9449-49cf-b220-041badec778f", "C001", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1133), 80000.0, "P003", 1 },
                    { "36309064-0dae-44d8-89b7-b9d0ef7d2997", "C004", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1199), 35000.0, "P011", 2 },
                    { "4b316817-56e0-43d7-98ef-ff30331fa678", "C001", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1127), 30000.0, "P001", 2 },
                    { "7c4aaef6-6d1d-4656-a300-b883acaa6fdb", "C003", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1187), 50000.0, "P008", 2 },
                    { "83c7ad92-0c9a-4fc9-89b8-a468b38b0df5", "C003", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1146), 15000.0, "P007", 5 },
                    { "8be870dd-092b-4d44-9826-366967554de3", "C002", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1143), 40000.0, "P006", 2 },
                    { "a3dbe60b-8a64-493e-b68a-11256fbc9ef0", "C004", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1202), 45000.0, "P012", 1 },
                    { "e01fd7dd-e1a6-4fc1-8a05-2ede7f9b7286", "C003", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1192), 60000.0, "P009", 1 },
                    { "e6614d77-89e5-4ac4-a804-de18dd83e0dd", "C004", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1195), 120000.0, "P010", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1248));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1251));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1253));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1257));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1262));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1315));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "0afb74e9-a6f5-4cef-a72d-b5a729ecb253", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", 5, null },
                    { "1ea07099-8f7a-4fb9-a6ed-c43fd38fcf90", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", 5, null },
                    { "51a32983-8a08-4bc2-b211-938ce23d2e29", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", 5, null },
                    { "51bf5370-483e-49e8-a26b-ed0be685551d", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", 5, null },
                    { "747c5da2-3c3c-4467-8d8e-fcef0eef9a77", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", 5, null },
                    { "bd4572f5-2449-4ace-ba68-6f6f4b5bed62", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", 5, null },
                    { "caffdfc7-4485-4189-80ec-6efc54afb1b7", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", 5, null },
                    { "d6c05515-dc0c-4045-aaba-c1ce780bdcb0", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", 5, null },
                    { "dfc2af29-3fa9-4d3d-89c0-3d84e649058e", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", 5, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(256));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(281));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "035eb5ea-b3d4-44d1-beff-536c46b33c88", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1400), "O006", 45000.0, "P012", 3 },
                    { "05a47f1a-b8ba-4b88-a697-230e67cf6b0b", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1416), "O009", 80000.0, "P003", 2 },
                    { "0a99587b-e19b-4a1d-acc5-808ea8124ecb", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1394), "O005", 120000.0, "P010", 1 },
                    { "0e51506e-e4e8-4ee1-9860-d70a67eec06f", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1396), "O006", 35000.0, "P011", 2 },
                    { "163b2f79-d897-48b8-a4ec-0dd15bbe5a5c", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1382), "O003", 40000.0, "P006", 3 },
                    { "24561973-b325-4290-895d-548c110f662f", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1430), "O012", 50000.0, "P008", 2 },
                    { "3252672f-7038-477d-9681-306c18fd8b70", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1402), "O007", 18000.0, "P013", 5 },
                    { "5c78aaca-5dfe-4792-8029-41a8be88e033", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1425), "O011", 40000.0, "P006", 2 },
                    { "64948bb2-ff09-4f81-8a40-af7d5ff3a6a6", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1411), "O008", 30000.0, "P001", 1 },
                    { "6a7d5401-534f-41d9-a4b4-3b3857a5e732", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1391), "O005", 60000.0, "P009", 1 },
                    { "7359b657-327d-4b55-9205-bff0d697bf5c", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1380), "O003", 25000.0, "P005", 2 },
                    { "794b410a-9123-403c-b62e-7660cb974528", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1423), "O010", 25000.0, "P005", 3 },
                    { "889051bf-11a2-40b8-b0ee-5c82b761a6d0", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1384), "O004", 15000.0, "P007", 4 },
                    { "964cabb5-45d1-4b8b-a556-72d4e1cfe8d2", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1441), "O014", 45000.0, "P012", 3 },
                    { "992156a6-9f4f-4cdf-b9ae-37e2a0296e26", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1445), "O014", 18000.0, "P013", 5 },
                    { "992de41e-78fe-4c48-af82-d951df01f9eb", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1450), "O015", 22000.0, "P015", 4 },
                    { "99d28cdc-5b32-41c6-b537-18d380067511", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1436), "O013", 120000.0, "P010", 1 },
                    { "9dfb6315-544e-4378-8a30-e93db5cf77cd", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1407), "O008", 22000.0, "P015", 4 },
                    { "ac5cf606-dc2f-44c3-8ba1-77c60c2e58b1", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1370), "O001", 20000.0, "P002", 5 },
                    { "b420359d-0f9e-4871-8365-07fe7debc5bd", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1439), "O013", 35000.0, "P011", 2 },
                    { "c7eed3d4-ad7d-4202-a4e9-ea1aef36033a", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1428), "O011", 15000.0, "P007", 4 },
                    { "c841246e-9743-4180-aa2a-c2dca8cafa0a", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1414), "O009", 20000.0, "P002", 6 },
                    { "ce2abe23-bc95-4b76-9cfc-1ee2b667b794", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1405), "O007", 90000.0, "P014", 2 },
                    { "d3be8116-f5ca-47b0-809a-4cec28ad1b3c", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1367), "O001", 30000.0, "P001", 3 },
                    { "e0540b90-e6ef-403d-8783-f7fbefa8fc2a", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1389), "O004", 50000.0, "P008", 2 },
                    { "e1ad1e0a-4cd7-4458-b72f-4804df59b7e0", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1434), "O012", 60000.0, "P009", 1 },
                    { "e20bc304-4b5f-45a6-b56a-7bc7bfab7101", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1377), "O002", 100000.0, "P004", 1 },
                    { "e83273ff-32ec-4f07-851f-3d330fe79ab1", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1373), "O002", 80000.0, "P003", 1 },
                    { "fa76b980-b6e0-4f2b-898b-07089f889002", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1419), "O010", 100000.0, "P004", 1 },
                    { "ff8ef6d3-4767-44e1-9d77-0beb72f9038e", new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1447), "O015", 90000.0, "P014", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9688));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R001",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R002",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R003",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R004",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(397));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R005",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R006",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R007",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R008",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R009",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R010",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R011",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R012",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R013",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R014",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R015",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1633), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1634) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1661), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1661) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1664), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1664) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1668), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1668) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1672), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1672) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1675), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1677), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1678) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1680), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1680) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1682), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1685), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1687), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1690), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1690) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1694), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1697), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1697) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1699), new DateTime(2025, 5, 13, 8, 29, 52, 703, DateTimeKind.Utc).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 13, 8, 29, 52, 702, DateTimeKind.Utc).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(475), new DateTime(2025, 5, 16, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(475), new DateTime(2025, 5, 15, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(468), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(476) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(507), new DateTime(2025, 5, 18, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(506), new DateTime(2025, 5, 17, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(506), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(508) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(512), new DateTime(2025, 5, 20, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(512), new DateTime(2025, 5, 19, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(511), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(520), new DateTime(2025, 5, 14, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(519), new DateTime(2025, 5, 14, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(519), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(520) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(525), new DateTime(2025, 5, 22, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(524), new DateTime(2025, 5, 21, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(522), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(525) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(529), new DateTime(2025, 5, 24, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(528), new DateTime(2025, 5, 23, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(528), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(529) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(534), new DateTime(2025, 5, 26, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(533), new DateTime(2025, 5, 25, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(533), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(534) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(538), new DateTime(2025, 5, 28, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(537), new DateTime(2025, 5, 27, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(537), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(539) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(542), new DateTime(2025, 5, 30, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(542), new DateTime(2025, 5, 29, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(541), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(543) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(547), new DateTime(2025, 6, 1, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(547), new DateTime(2025, 5, 31, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(545), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(548) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(551), new DateTime(2025, 6, 3, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(550), new DateTime(2025, 6, 2, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(550), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(551) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(556), new DateTime(2025, 6, 5, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(556), new DateTime(2025, 6, 4, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(555), new DateTime(2025, 5, 13, 15, 29, 52, 703, DateTimeKind.Local).AddTicks(557) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "0b4aeceb-05bd-46c2-99a8-adc5771e5dea");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "1d04b17b-3d43-41d4-aaf4-27e2d5dfd5bd");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "29620272-3b8c-4cc0-a8d9-239ee037e62b");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "2fa4e09e-9449-49cf-b220-041badec778f");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "36309064-0dae-44d8-89b7-b9d0ef7d2997");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "4b316817-56e0-43d7-98ef-ff30331fa678");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "7c4aaef6-6d1d-4656-a300-b883acaa6fdb");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "83c7ad92-0c9a-4fc9-89b8-a468b38b0df5");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "8be870dd-092b-4d44-9826-366967554de3");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "a3dbe60b-8a64-493e-b68a-11256fbc9ef0");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e01fd7dd-e1a6-4fc1-8a05-2ede7f9b7286");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e6614d77-89e5-4ac4-a804-de18dd83e0dd");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "0afb74e9-a6f5-4cef-a72d-b5a729ecb253");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "1ea07099-8f7a-4fb9-a6ed-c43fd38fcf90");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "51a32983-8a08-4bc2-b211-938ce23d2e29");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "51bf5370-483e-49e8-a26b-ed0be685551d");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "747c5da2-3c3c-4467-8d8e-fcef0eef9a77");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "bd4572f5-2449-4ace-ba68-6f6f4b5bed62");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "caffdfc7-4485-4189-80ec-6efc54afb1b7");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "d6c05515-dc0c-4045-aaba-c1ce780bdcb0");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "dfc2af29-3fa9-4d3d-89c0-3d84e649058e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "035eb5ea-b3d4-44d1-beff-536c46b33c88");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "05a47f1a-b8ba-4b88-a697-230e67cf6b0b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0a99587b-e19b-4a1d-acc5-808ea8124ecb");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0e51506e-e4e8-4ee1-9860-d70a67eec06f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "163b2f79-d897-48b8-a4ec-0dd15bbe5a5c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "24561973-b325-4290-895d-548c110f662f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "3252672f-7038-477d-9681-306c18fd8b70");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5c78aaca-5dfe-4792-8029-41a8be88e033");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "64948bb2-ff09-4f81-8a40-af7d5ff3a6a6");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "6a7d5401-534f-41d9-a4b4-3b3857a5e732");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "7359b657-327d-4b55-9205-bff0d697bf5c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "794b410a-9123-403c-b62e-7660cb974528");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "889051bf-11a2-40b8-b0ee-5c82b761a6d0");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "964cabb5-45d1-4b8b-a556-72d4e1cfe8d2");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "992156a6-9f4f-4cdf-b9ae-37e2a0296e26");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "992de41e-78fe-4c48-af82-d951df01f9eb");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "99d28cdc-5b32-41c6-b537-18d380067511");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "9dfb6315-544e-4378-8a30-e93db5cf77cd");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ac5cf606-dc2f-44c3-8ba1-77c60c2e58b1");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "b420359d-0f9e-4871-8365-07fe7debc5bd");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "c7eed3d4-ad7d-4202-a4e9-ea1aef36033a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "c841246e-9743-4180-aa2a-c2dca8cafa0a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ce2abe23-bc95-4b76-9cfc-1ee2b667b794");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "d3be8116-f5ca-47b0-809a-4cec28ad1b3c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e0540b90-e6ef-403d-8783-f7fbefa8fc2a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e1ad1e0a-4cd7-4458-b72f-4804df59b7e0");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e20bc304-4b5f-45a6-b56a-7bc7bfab7101");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e83273ff-32ec-4f07-851f-3d330fe79ab1");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "fa76b980-b6e0-4f2b-898b-07089f889002");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ff8ef6d3-4767-44e1-9d77-0beb72f9038e");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "ContractImage");

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4684), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4685) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4687), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4687) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4691), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4693), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4695), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4696) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4698), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4698) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4700), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4702), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4703) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4705), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4705) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4707), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4707) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4710), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4711) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4713), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4713) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4715), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4715) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4774), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4777), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4777) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3923), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3924) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3927), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3928) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3930), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3932), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3933) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "09f62286-6500-4b80-9364-77dedc6f3205", "C003", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4839), 50000.0, "P008", 2 },
                    { "32cdcf59-c0ef-4b9d-949d-0518f34ebad3", "C002", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4832), 40000.0, "P006", 2 },
                    { "41074a7d-6c85-4596-8399-57c4f2eb9894", "C004", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4850), 35000.0, "P011", 2 },
                    { "59ee64be-963d-44c5-bf7c-b4d7b5f4c328", "C001", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4822), 80000.0, "P003", 1 },
                    { "7743132a-9010-4a3e-a770-2f7a03840aad", "C004", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4852), 45000.0, "P012", 1 },
                    { "8a17b85e-964d-404f-a35d-c2d5d05bf995", "C002", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4825), 100000.0, "P004", 1 },
                    { "b23f4087-b4ba-49bc-a137-e17d318af514", "C001", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4818), 20000.0, "P002", 1 },
                    { "c3f57a76-f030-4451-bee8-7c8f4a278d97", "C001", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4813), 30000.0, "P001", 2 },
                    { "c4a75511-3f99-4504-9fff-350282dd099a", "C004", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4846), 120000.0, "P010", 1 },
                    { "da05f98d-86a9-4c17-bf47-7af37421c7a7", "C003", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4836), 15000.0, "P007", 5 },
                    { "e02f9d7f-ba3d-4243-9b2f-c4b1da944fc2", "C002", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4828), 25000.0, "P005", 3 },
                    { "f3cc8e42-5726-43d2-8783-526e04c5517d", "C003", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4842), 60000.0, "P009", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2959));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3238));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3245));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3248));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(4990));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "0c13d1f2-5869-45ec-a7a6-48cad80e8848", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", 5, null },
                    { "1442f63b-4e28-409a-a32f-dfdbd29b5d6f", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", 5, null },
                    { "32f32682-b63d-4cce-8908-b609092d4e67", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", 5, null },
                    { "57ae6f17-607f-47d6-9bf2-36bdf8b6f2cc", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", 5, null },
                    { "725a0272-16d4-40b9-bbe9-f20ea2d23e95", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", 5, null },
                    { "88874e03-033a-40fa-a654-cc415449b5c5", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", 5, null },
                    { "a9d96248-6598-4ec2-a6bc-8f9da65a15f8", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", 5, null },
                    { "ef456794-7f4b-4f89-a8bd-b9d44c8d3979", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", 5, null },
                    { "f808599f-58b0-49b7-a552-8e6928808d52", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", 5, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3890));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "07500a2f-2c1a-4abd-b20d-42e27efbc008", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5125), "O013", 120000.0, "P010", 1 },
                    { "088d4ed4-5601-4a51-a55a-c8adc503769f", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5055), "O006", 45000.0, "P012", 3 },
                    { "0d676fc2-ed13-40c6-a435-969aa4b6fc78", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5106), "O010", 100000.0, "P004", 1 },
                    { "11cc2e4f-1b1b-4850-8180-a54f2df4ed2c", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5029), "O002", 100000.0, "P004", 1 },
                    { "2ef0411c-b628-4cf5-bafb-05b9198d9a8f", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5071), "O009", 20000.0, "P002", 6 },
                    { "3370f374-0b9c-4904-97fe-a336ab749812", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5067), "O008", 30000.0, "P001", 1 },
                    { "399d272c-493e-4680-84dd-0a8c4558075d", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5049), "O005", 120000.0, "P010", 1 },
                    { "422ee7ca-7ffe-4d7d-bbbc-e91376c65a97", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5113), "O011", 40000.0, "P006", 2 },
                    { "4dd380a2-0fef-4b9a-b3ed-f10e62a4ca24", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5052), "O006", 35000.0, "P011", 2 },
                    { "5198e180-04db-45f7-98ad-07b16d6c45bc", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5074), "O009", 80000.0, "P003", 2 },
                    { "52a42dbf-3062-4794-8b28-f52cd44584d5", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5133), "O014", 18000.0, "P013", 5 },
                    { "54700c81-0208-42df-aafa-76111951abe4", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5064), "O008", 22000.0, "P015", 4 },
                    { "5f88668b-7598-4aa0-ba23-f342ee4ea4ec", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5121), "O012", 60000.0, "P009", 1 },
                    { "690cbf95-1c15-42ee-a5b1-74b697d447bf", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5059), "O007", 18000.0, "P013", 5 },
                    { "84ef3f89-0d66-469a-b7fb-299cf213dbde", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5038), "O004", 15000.0, "P007", 4 },
                    { "851c6bef-dc3d-4fe1-83f2-69341ca46817", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5118), "O012", 50000.0, "P008", 2 },
                    { "9115e935-c3b6-4a88-abf2-decaff6998ab", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5128), "O013", 35000.0, "P011", 2 },
                    { "99830c16-ba9e-4870-8b89-cbe920fc7b8d", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5047), "O005", 60000.0, "P009", 1 },
                    { "a8a7236d-ad76-4d84-942f-23141991b406", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5033), "O003", 25000.0, "P005", 2 },
                    { "ad79decf-2258-4c45-b441-2727606d0005", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5109), "O010", 25000.0, "P005", 3 },
                    { "ad8ab8d0-8264-4c8a-a54d-e5ea5a300d4d", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5026), "O002", 80000.0, "P003", 1 },
                    { "e10368c5-52db-4c4d-aa1f-2294dc0fc8e5", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5137), "O015", 90000.0, "P014", 2 },
                    { "e1cfd85e-3f3b-4588-b3d0-03d4cb42d05c", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5062), "O007", 90000.0, "P014", 2 },
                    { "e4b312f1-5158-47f8-9fdd-fc029c1ad1e0", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5020), "O001", 30000.0, "P001", 3 },
                    { "e5b1fe26-de7e-476a-abab-57acfd8ea05c", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5023), "O001", 20000.0, "P002", 5 },
                    { "e642fb38-fc04-49d4-925f-f6af6875c956", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5115), "O011", 15000.0, "P007", 4 },
                    { "e6a8f699-4712-4535-b477-031236ea4852", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5130), "O014", 45000.0, "P012", 3 },
                    { "ecb32d17-4893-4595-9f33-960175cf5d04", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5041), "O004", 50000.0, "P008", 2 },
                    { "f372e35d-5741-4358-ba52-2825eadc386a", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5140), "O015", 22000.0, "P015", 4 },
                    { "f8718435-0dd6-49db-9244-fd0327dee0cd", new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5035), "O003", 40000.0, "P006", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5238));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5272));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R001",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R002",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R003",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R004",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R005",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R006",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R007",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R008",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R009",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R010",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R011",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R012",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R013",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R014",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R015",
                column: "CreatedDate",
                value: new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5331), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5332) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5340), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5341) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5344), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5344) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5346), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5347) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5349), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5349) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5353), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5356), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5356) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5359), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5359) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5361), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5362) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5364), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5364) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5367), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5367) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5369), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5370) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5372), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5372) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5377), new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(5377) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 5, 10, 13, 55, 31, 902, DateTimeKind.Utc).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4111), new DateTime(2025, 5, 13, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4110), new DateTime(2025, 5, 12, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4105), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4112) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4117), new DateTime(2025, 5, 15, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4117), new DateTime(2025, 5, 14, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4116), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4123), new DateTime(2025, 5, 17, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4122), new DateTime(2025, 5, 16, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4120), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4127), new DateTime(2025, 5, 11, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4127), new DateTime(2025, 5, 11, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4126), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4132), new DateTime(2025, 5, 19, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4131), new DateTime(2025, 5, 18, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4130), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4132) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4139), new DateTime(2025, 5, 21, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4138), new DateTime(2025, 5, 20, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4137), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4143), new DateTime(2025, 5, 23, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4142), new DateTime(2025, 5, 22, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4142), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4147), new DateTime(2025, 5, 25, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4146), new DateTime(2025, 5, 24, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4146), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4151), new DateTime(2025, 5, 27, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4150), new DateTime(2025, 5, 26, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4150), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4155), new DateTime(2025, 5, 29, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4154), new DateTime(2025, 5, 28, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4154), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4160), new DateTime(2025, 5, 31, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4159), new DateTime(2025, 5, 30, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4159), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4164), new DateTime(2025, 6, 2, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4163), new DateTime(2025, 6, 1, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4163), new DateTime(2025, 5, 10, 20, 55, 31, 902, DateTimeKind.Local).AddTicks(4164) });
        }
    }
}
