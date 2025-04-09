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
                keyValue: "0ce0208a-55ad-4e8f-8be0-3eca01589c9d");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "38728cd5-47a1-45eb-83c0-1a8c5687b04b");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "3b717d38-8ea6-484f-934d-d52a9e451b2c");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "505bc699-3d42-4528-b019-5d1cc4e4dadc");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "bee936c1-a692-42c9-9c05-12d2486aebc9");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "c0b52290-390a-4ac8-b3ab-4a7f44b432e2");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "caffbc09-9c6a-4ecc-8457-08f79db76fb7");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "cca6168d-3e03-4047-bd10-09dc928bc4e5");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "dca0a92c-a9a5-4f90-990b-e337225e0999");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "dd42c045-8ef8-425b-93fd-f3acca859517");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e0c4cb3f-1f46-493e-b7b5-4c78466bbd66");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "e9eb6604-bef7-4e57-a767-0d50f8a56d0e");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "5d0862ef-42ed-4e6f-b008-11fcc07f0282");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "61240fca-553c-44c7-b3a2-802e404397da");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "65d0d692-e10e-4c73-86ee-4d3f684295e4");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "6e45a867-71ef-49db-84a8-6bc0170b70db");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "712c13ba-0a7a-411d-b8bd-0551f1db720c");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "78825b8c-80a2-4d5c-b2e6-7ecc10bd61b3");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "9531b099-804f-484a-a096-9f1185fad8ad");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "ccb19d72-2ed9-4bb7-b9c6-6f9ddde6f459");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "ea04b688-b69c-4ae6-96fb-ebd34902b600");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0a8275b0-fa79-4caf-abb7-67ce9cd59d7f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0ae26f83-0881-4632-ae2c-a0a7f06f390e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0ae87d5e-1edb-443d-b8d9-164a441286f5");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "119a958a-cfa3-4986-a927-e3b8dd839069");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "134891de-751e-4151-9142-e5cac3f319de");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "136d1b68-33c4-4649-8825-78f9840f607c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "165b0cea-890f-443c-ad25-1629586baf81");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1d940c8f-3f10-4a04-b6ff-b6a3a6d2e982");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "237b4094-9004-4844-bf73-643ebbeedff9");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "37679a45-e5db-455a-93eb-9f05ac283d7d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "3d01ca37-4af9-49cb-a8cf-58558461ff41");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "465b931e-35d5-4f1e-a798-5a56957771cf");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "48c31f63-3776-4aa2-8cd2-397cadd4f84f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "4e49bd0c-32b0-4b30-8efa-52fd1abc0ba4");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5c6e806a-b1bf-41ff-bfee-0d0198eec304");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "66ba1544-26a0-4b90-8008-637e3aeacc4b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "6ca2b2d1-63f3-4bc7-9d33-d0e766059729");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "7be2168c-c817-4abe-99fc-3c4e3b83d22b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "80aee894-8028-4cf1-a945-8c749ae7fce1");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "929225d6-0ac2-4d75-85cb-f5e5473e0857");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "95299bdc-6256-4558-8321-6a8a6d71fae9");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "977a609a-ebce-4462-a051-66a104ff3c37");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "9bca7b7a-8a9a-4442-925a-6b40a3bfce75");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "a9bd492b-4afb-46d3-baa7-28d56c0f8332");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "b69b6841-381c-4a81-a033-e05ee02771d2");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e23df5ff-5649-4713-b0c2-2ef477bb7e85");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "e4d059cc-0d3e-487f-a631-b369b969acca");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f4278aa9-5959-434a-b3ef-77ba1e9eb8dd");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f644f413-9ac4-47ee-b843-82e0042edfec");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f78ef8ad-8125-48fe-8496-7434f9ac68e7");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Request",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Request",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1597));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1603));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1635), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1636) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1638), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1639) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1641), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1641) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1643), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1644) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1646), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1646) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1648), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1650), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1651) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1652), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1656), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1656) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1658), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1659) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1661), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1661) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1663), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1664) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1665), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1666) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1667), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1668) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1670), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1670) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(958), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(962), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(962) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(964), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(966), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "014fc7c7-9897-4e75-88c3-bccfbf832eda", "C002", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1741), 100000.0, "P004", 1 },
                    { "1f1d3665-349c-48dd-96d0-3b889c8df38d", "C001", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1707), 20000.0, "P002", 1 },
                    { "29ddc6cc-4659-4837-9eb3-dd7cdb0459a6", "C001", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1710), 80000.0, "P003", 1 },
                    { "382d76a5-0922-40b1-b65c-c5c1a943011c", "C003", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1752), 15000.0, "P007", 5 },
                    { "3cb9d33d-6e9e-4d1c-a8c5-3147011a00e2", "C002", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1746), 25000.0, "P005", 3 },
                    { "46ef90d4-1461-437f-8444-979e56be179a", "C002", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1749), 40000.0, "P006", 2 },
                    { "5d670c01-2364-44b7-a11d-ab94ae47e590", "C003", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1761), 60000.0, "P009", 1 },
                    { "6644339c-dfe9-47a2-af60-a4599e458750", "C004", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1767), 35000.0, "P011", 2 },
                    { "7cf75ee6-814c-45ad-b433-9da757fe58e3", "C004", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1771), 45000.0, "P012", 1 },
                    { "92ee0ea3-7954-4832-9298-9195f89c3bbb", "C001", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1703), 30000.0, "P001", 2 },
                    { "b4e5fc0c-82ac-418e-aa8c-8dacacb3db46", "C003", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1755), 50000.0, "P008", 2 },
                    { "bb13f71c-4a7e-4a9f-9d9f-2a968ef2f6ad", "C004", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1764), 120000.0, "P010", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1826));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(374));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1425));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1433));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1929));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "2b23329a-9d3c-49d8-8aaa-55977de64289", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null, null },
                    { "3de718ee-86df-45db-8dd8-b1ce976632ad", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null, null },
                    { "452560f4-4e9a-43c6-9db8-4efea74ef05a", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null, null },
                    { "563b86ac-8b86-46c6-adfe-941e8d68dfd4", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null, null },
                    { "7838b926-41fd-4e1e-8f44-39b1a09ff12b", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null, null },
                    { "a1ccb9a5-dbe9-4db9-97a9-4f5865892351", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null, null },
                    { "ec594217-6018-4187-92d9-120d95b78ffd", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null, null },
                    { "fb65e9c7-da10-4c83-b312-e13d351f4255", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null, null },
                    { "ffe6a854-76f0-4932-be2d-8df401fe98aa", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(892));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(897));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(921));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "017cb2c3-b3d6-4d86-8c10-d784aee06e1c", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2041), "O013", 120000.0, "P010", 1 },
                    { "1151e08b-be26-497e-b951-745249ba3f3d", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2082), "O014", 45000.0, "P012", 3 },
                    { "11597b3f-90da-4644-8f80-68b2ffd50d14", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1971), "O002", 80000.0, "P003", 1 },
                    { "1ba974da-3a0f-4908-be1f-700a2cf89209", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2030), "O011", 40000.0, "P006", 2 },
                    { "21339f4e-ff7d-4793-b38d-5102649fef6b", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2011), "O008", 22000.0, "P015", 4 },
                    { "22ec5710-b2c5-4f5b-89cb-1c21c1fcd8e1", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1995), "O005", 120000.0, "P010", 1 },
                    { "25e0c117-b228-4c91-9a61-bcac8f3e5b26", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2021), "O009", 80000.0, "P003", 2 },
                    { "35895917-7270-4595-8c02-25482db32139", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2093), "O015", 22000.0, "P015", 4 },
                    { "35e80416-0370-4736-9205-7fb91a6b11a0", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1965), "O001", 30000.0, "P001", 3 },
                    { "42453320-b8e0-41a1-9d5f-56e4448e88de", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2027), "O010", 25000.0, "P005", 3 },
                    { "4bb8e1da-133c-4c10-8be3-123ed179ecdc", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2038), "O012", 60000.0, "P009", 1 },
                    { "57cf291f-0dd1-4059-b4e8-8a33b87a6252", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1998), "O006", 35000.0, "P011", 2 },
                    { "581f3d8f-ca32-4d84-a6a3-34a0a31836fc", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1982), "O003", 40000.0, "P006", 3 },
                    { "58caec02-6a18-4be0-af4c-9ceb52423940", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2032), "O011", 15000.0, "P007", 4 },
                    { "6fea0560-d973-4476-b76b-7e929af9ad65", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1984), "O004", 15000.0, "P007", 4 },
                    { "757a3577-d0cf-43af-af0f-048c3871a9af", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2003), "O006", 45000.0, "P012", 3 },
                    { "8267a128-dc43-41a8-aa3f-170626e3ac9c", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1979), "O003", 25000.0, "P005", 2 },
                    { "8ce9fa8f-2aa9-4f97-bbba-bf559e5d9fb6", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1989), "O004", 50000.0, "P008", 2 },
                    { "96b06755-5c84-4530-b08f-11f5142d1aae", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2018), "O009", 20000.0, "P002", 6 },
                    { "9ac8fccd-63c4-4847-aba7-48553f4537e3", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1968), "O001", 20000.0, "P002", 5 },
                    { "af5e8472-258d-4a10-ad2a-f181837dd46a", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2034), "O012", 50000.0, "P008", 2 },
                    { "c1312e34-bb29-4d63-b94c-25d65eae61dc", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2023), "O010", 100000.0, "P004", 1 },
                    { "c50431d2-4394-4086-9978-2ebbd837f1d7", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2015), "O008", 30000.0, "P001", 1 },
                    { "c774feba-b179-48aa-b303-7782c38a160e", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2090), "O015", 90000.0, "P014", 2 },
                    { "d1ca069e-e478-430e-80bc-be98a52c12f1", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1976), "O002", 100000.0, "P004", 1 },
                    { "d32b1962-a854-4026-a621-26fbbb427459", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2079), "O013", 35000.0, "P011", 2 },
                    { "ddbd4504-0099-41a6-b976-c41e663ca2d9", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2086), "O014", 18000.0, "P013", 5 },
                    { "ea7258a9-d761-4180-8a36-2933e05df207", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(1992), "O005", 60000.0, "P009", 1 },
                    { "ef3773ca-b66f-40dc-852b-e2e6c4218b7e", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2006), "O007", 18000.0, "P013", 5 },
                    { "fc84724a-468d-460f-bd4b-588da4e73110", new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2008), "O007", 90000.0, "P014", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(259));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(272));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R001",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(991), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R002",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1013), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R003",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1018), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R004",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1022), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R005",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1025), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R006",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1029), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R007",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1032), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R008",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1036), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R009",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1039), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R010",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1042), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R011",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1047), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R012",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1072), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R013",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1075), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R014",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1078), null });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "RequestId",
                keyValue: "R015",
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1082), null });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2275), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2276) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2279), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2280) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2282), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2283) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2285), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2286) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2290), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2293), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2293) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2296), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2296) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2299), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2299) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2302), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2302) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2305), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2308), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2309) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2311), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2312) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2316), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2316) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2319), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2319) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2322), new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(2322) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(194));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 5, 55, 30, 360, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1121), new DateTime(2025, 4, 12, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1120), new DateTime(2025, 4, 11, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1115), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1121) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1127), new DateTime(2025, 4, 14, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1126), new DateTime(2025, 4, 13, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1126), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1128) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1133), new DateTime(2025, 4, 16, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1131), new DateTime(2025, 4, 15, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1131), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1133) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1139), new DateTime(2025, 4, 10, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1138), new DateTime(2025, 4, 10, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1137), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1139) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1143), new DateTime(2025, 4, 18, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1142), new DateTime(2025, 4, 17, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1142), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1143) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1147), new DateTime(2025, 4, 20, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1146), new DateTime(2025, 4, 19, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1146), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1147) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1151), new DateTime(2025, 4, 22, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1150), new DateTime(2025, 4, 21, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1150), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1151) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1156), new DateTime(2025, 4, 24, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1155), new DateTime(2025, 4, 23, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1155), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1156) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1160), new DateTime(2025, 4, 26, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1159), new DateTime(2025, 4, 25, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1158), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1164), new DateTime(2025, 4, 28, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1163), new DateTime(2025, 4, 27, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1162), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1165) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1168), new DateTime(2025, 4, 30, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1167), new DateTime(2025, 4, 29, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1167), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1174), new DateTime(2025, 5, 2, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1173), new DateTime(2025, 5, 1, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1172), new DateTime(2025, 4, 9, 12, 55, 30, 360, DateTimeKind.Local).AddTicks(1175) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "014fc7c7-9897-4e75-88c3-bccfbf832eda");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "1f1d3665-349c-48dd-96d0-3b889c8df38d");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "29ddc6cc-4659-4837-9eb3-dd7cdb0459a6");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "382d76a5-0922-40b1-b65c-c5c1a943011c");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "3cb9d33d-6e9e-4d1c-a8c5-3147011a00e2");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "46ef90d4-1461-437f-8444-979e56be179a");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "5d670c01-2364-44b7-a11d-ab94ae47e590");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "6644339c-dfe9-47a2-af60-a4599e458750");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "7cf75ee6-814c-45ad-b433-9da757fe58e3");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "92ee0ea3-7954-4832-9298-9195f89c3bbb");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "b4e5fc0c-82ac-418e-aa8c-8dacacb3db46");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "bb13f71c-4a7e-4a9f-9d9f-2a968ef2f6ad");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "2b23329a-9d3c-49d8-8aaa-55977de64289");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "3de718ee-86df-45db-8dd8-b1ce976632ad");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "452560f4-4e9a-43c6-9db8-4efea74ef05a");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "563b86ac-8b86-46c6-adfe-941e8d68dfd4");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "7838b926-41fd-4e1e-8f44-39b1a09ff12b");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "a1ccb9a5-dbe9-4db9-97a9-4f5865892351");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "ec594217-6018-4187-92d9-120d95b78ffd");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "fb65e9c7-da10-4c83-b312-e13d351f4255");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "ffe6a854-76f0-4932-be2d-8df401fe98aa");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "017cb2c3-b3d6-4d86-8c10-d784aee06e1c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1151e08b-be26-497e-b951-745249ba3f3d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "11597b3f-90da-4644-8f80-68b2ffd50d14");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "1ba974da-3a0f-4908-be1f-700a2cf89209");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "21339f4e-ff7d-4793-b38d-5102649fef6b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "22ec5710-b2c5-4f5b-89cb-1c21c1fcd8e1");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "25e0c117-b228-4c91-9a61-bcac8f3e5b26");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "35895917-7270-4595-8c02-25482db32139");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "35e80416-0370-4736-9205-7fb91a6b11a0");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "42453320-b8e0-41a1-9d5f-56e4448e88de");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "4bb8e1da-133c-4c10-8be3-123ed179ecdc");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "57cf291f-0dd1-4059-b4e8-8a33b87a6252");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "581f3d8f-ca32-4d84-a6a3-34a0a31836fc");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "58caec02-6a18-4be0-af4c-9ceb52423940");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "6fea0560-d973-4476-b76b-7e929af9ad65");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "757a3577-d0cf-43af-af0f-048c3871a9af");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "8267a128-dc43-41a8-aa3f-170626e3ac9c");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "8ce9fa8f-2aa9-4f97-bbba-bf559e5d9fb6");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "96b06755-5c84-4530-b08f-11f5142d1aae");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "9ac8fccd-63c4-4847-aba7-48553f4537e3");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "af5e8472-258d-4a10-ad2a-f181837dd46a");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "c1312e34-bb29-4d63-b94c-25d65eae61dc");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "c50431d2-4394-4086-9978-2ebbd837f1d7");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "c774feba-b179-48aa-b303-7782c38a160e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "d1ca069e-e478-430e-80bc-be98a52c12f1");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "d32b1962-a854-4026-a621-26fbbb427459");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ddbd4504-0099-41a6-b976-c41e663ca2d9");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ea7258a9-d761-4180-8a36-2933e05df207");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ef3773ca-b66f-40dc-852b-e2e6c4218b7e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "fc84724a-468d-460f-bd4b-588da4e73110");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Request");

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(44));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(55));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(59));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(112), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(114) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(116), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(117) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(119), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(119) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(122), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(122) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(126), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(126) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(128), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(129) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(131), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(131) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(134), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(134) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(169), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(169) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(172), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(173) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(175), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(176) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(178), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(179) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(182), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(183) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(185), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(186) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(188), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(189) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9277), new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9277) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9280), new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9285), new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9285) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9288), new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9288) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0ce0208a-55ad-4e8f-8be0-3eca01589c9d", "C004", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(267), 35000.0, "P011", 2 },
                    { "38728cd5-47a1-45eb-83c0-1a8c5687b04b", "C001", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(228), 30000.0, "P001", 2 },
                    { "3b717d38-8ea6-484f-934d-d52a9e451b2c", "C003", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(252), 15000.0, "P007", 5 },
                    { "505bc699-3d42-4528-b019-5d1cc4e4dadc", "C002", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(240), 100000.0, "P004", 1 },
                    { "bee936c1-a692-42c9-9c05-12d2486aebc9", "C003", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(256), 50000.0, "P008", 2 },
                    { "c0b52290-390a-4ac8-b3ab-4a7f44b432e2", "C002", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(248), 40000.0, "P006", 2 },
                    { "caffbc09-9c6a-4ecc-8457-08f79db76fb7", "C002", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(244), 25000.0, "P005", 3 },
                    { "cca6168d-3e03-4047-bd10-09dc928bc4e5", "C004", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(271), 45000.0, "P012", 1 },
                    { "dca0a92c-a9a5-4f90-990b-e337225e0999", "C004", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(262), 120000.0, "P010", 1 },
                    { "dd42c045-8ef8-425b-93fd-f3acca859517", "C001", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(232), 20000.0, "P002", 1 },
                    { "e0c4cb3f-1f46-493e-b7b5-4c78466bbd66", "C001", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(237), 80000.0, "P003", 1 },
                    { "e9eb6604-bef7-4e57-a767-0d50f8a56d0e", "C003", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(259), 60000.0, "P009", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9840));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(423));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "5d0862ef-42ed-4e6f-b008-11fcc07f0282", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null, null },
                    { "61240fca-553c-44c7-b3a2-802e404397da", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null, null },
                    { "65d0d692-e10e-4c73-86ee-4d3f684295e4", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null, null },
                    { "6e45a867-71ef-49db-84a8-6bc0170b70db", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null, null },
                    { "712c13ba-0a7a-411d-b8bd-0551f1db720c", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null, null },
                    { "78825b8c-80a2-4d5c-b2e6-7ecc10bd61b3", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null, null },
                    { "9531b099-804f-484a-a096-9f1185fad8ad", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null, null },
                    { "ccb19d72-2ed9-4bb7-b9c6-6f9ddde6f459", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null, null },
                    { "ea04b688-b69c-4ae6-96fb-ebd34902b600", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0a8275b0-fa79-4caf-abb7-67ce9cd59d7f", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(499), "O006", 45000.0, "P012", 3 },
                    { "0ae26f83-0881-4632-ae2c-a0a7f06f390e", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(553), "O009", 80000.0, "P003", 2 },
                    { "0ae87d5e-1edb-443d-b8d9-164a441286f5", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(495), "O006", 35000.0, "P011", 2 },
                    { "119a958a-cfa3-4986-a927-e3b8dd839069", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(484), "O004", 50000.0, "P008", 2 },
                    { "134891de-751e-4151-9142-e5cac3f319de", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(541), "O008", 22000.0, "P015", 4 },
                    { "136d1b68-33c4-4649-8825-78f9840f607c", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(556), "O010", 100000.0, "P004", 1 },
                    { "165b0cea-890f-443c-ad25-1629586baf81", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(473), "O003", 25000.0, "P005", 2 },
                    { "1d940c8f-3f10-4a04-b6ff-b6a3a6d2e982", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(584), "O014", 45000.0, "P012", 3 },
                    { "237b4094-9004-4844-bf73-643ebbeedff9", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(548), "O009", 20000.0, "P002", 6 },
                    { "37679a45-e5db-455a-93eb-9f05ac283d7d", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(590), "O015", 90000.0, "P014", 2 },
                    { "3d01ca37-4af9-49cb-a8cf-58558461ff41", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(481), "O004", 15000.0, "P007", 4 },
                    { "465b931e-35d5-4f1e-a798-5a56957771cf", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(562), "O011", 40000.0, "P006", 2 },
                    { "48c31f63-3776-4aa2-8cd2-397cadd4f84f", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(576), "O013", 120000.0, "P010", 1 },
                    { "4e49bd0c-32b0-4b30-8efa-52fd1abc0ba4", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(478), "O003", 40000.0, "P006", 3 },
                    { "5c6e806a-b1bf-41ff-bfee-0d0198eec304", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(470), "O002", 100000.0, "P004", 1 },
                    { "66ba1544-26a0-4b90-8008-637e3aeacc4b", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(573), "O012", 60000.0, "P009", 1 },
                    { "6ca2b2d1-63f3-4bc7-9d33-d0e766059729", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(492), "O005", 120000.0, "P010", 1 },
                    { "7be2168c-c817-4abe-99fc-3c4e3b83d22b", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(559), "O010", 25000.0, "P005", 3 },
                    { "80aee894-8028-4cf1-a945-8c749ae7fce1", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(502), "O007", 18000.0, "P013", 5 },
                    { "929225d6-0ac2-4d75-85cb-f5e5473e0857", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(567), "O011", 15000.0, "P007", 4 },
                    { "95299bdc-6256-4558-8321-6a8a6d71fae9", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(488), "O005", 60000.0, "P009", 1 },
                    { "977a609a-ebce-4462-a051-66a104ff3c37", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(458), "O001", 30000.0, "P001", 3 },
                    { "9bca7b7a-8a9a-4442-925a-6b40a3bfce75", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(467), "O002", 80000.0, "P003", 1 },
                    { "a9bd492b-4afb-46d3-baa7-28d56c0f8332", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(595), "O015", 22000.0, "P015", 4 },
                    { "b69b6841-381c-4a81-a033-e05ee02771d2", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(464), "O001", 20000.0, "P002", 5 },
                    { "e23df5ff-5649-4713-b0c2-2ef477bb7e85", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(587), "O014", 18000.0, "P013", 5 },
                    { "e4d059cc-0d3e-487f-a631-b369b969acca", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(545), "O008", 30000.0, "P001", 1 },
                    { "f4278aa9-5959-434a-b3ef-77ba1e9eb8dd", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(581), "O013", 35000.0, "P011", 2 },
                    { "f644f413-9ac4-47ee-b843-82e0042edfec", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(506), "O007", 90000.0, "P014", 2 },
                    { "f78ef8ad-8125-48fe-8496-7434f9ac68e7", new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(570), "O012", 50000.0, "P008", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8531));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(810), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(811) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(815), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(816) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(818), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(819) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(822), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(825), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(825) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(828), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(828) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(831), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(834), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(834) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(838), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(839) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(842), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(842) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(845), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(845) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(848), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(851), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(852) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(854), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(858), new DateTime(2025, 4, 8, 19, 51, 43, 829, DateTimeKind.Utc).AddTicks(858) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 4, 8, 19, 51, 43, 828, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9450), new DateTime(2025, 4, 12, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9449), new DateTime(2025, 4, 11, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9432), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9451) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9458), new DateTime(2025, 4, 14, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9457), new DateTime(2025, 4, 13, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9456), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9466), new DateTime(2025, 4, 16, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9463), new DateTime(2025, 4, 15, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9463), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9466) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9470), new DateTime(2025, 4, 10, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9470), new DateTime(2025, 4, 10, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9469), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9471) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9475), new DateTime(2025, 4, 18, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9474), new DateTime(2025, 4, 17, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9473), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9479), new DateTime(2025, 4, 20, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9479), new DateTime(2025, 4, 19, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9478), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9484), new DateTime(2025, 4, 22, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9483), new DateTime(2025, 4, 21, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9482), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9491), new DateTime(2025, 4, 24, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9490), new DateTime(2025, 4, 23, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9490), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9495), new DateTime(2025, 4, 26, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9495), new DateTime(2025, 4, 25, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9494), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9496) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9500), new DateTime(2025, 4, 28, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9499), new DateTime(2025, 4, 27, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9499), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9504), new DateTime(2025, 4, 30, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9504), new DateTime(2025, 4, 29, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9503), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9505) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9551), new DateTime(2025, 5, 2, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9551), new DateTime(2025, 5, 1, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9550), new DateTime(2025, 4, 9, 2, 51, 43, 828, DateTimeKind.Local).AddTicks(9552) });
        }
    }
}
