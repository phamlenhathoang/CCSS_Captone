using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_googleId_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "GoogleId",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A001",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A002",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A003",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A004",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A005",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A006",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A007",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A008",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A009",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A010",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A011",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A012",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A013",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A014",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A015",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A016",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A017",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A018",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A019",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A020",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A021",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A022",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A023",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A024",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A025",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A026",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A027",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A028",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A029",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A030",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A031",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A032",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A033",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A034",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A035",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A036",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A037",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A038",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A039",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "A040",
                column: "GoogleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI1",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI10",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI11",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI12",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI13",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI14",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI15",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI2",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI3",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI4",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI5",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI6",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI7",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI8",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "AccountImage",
                keyColumn: "AccountImageId",
                keyValue: "AI9",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8435), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8439), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8439) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8442), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8442) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8445), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8445) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT005",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8448), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8448) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT006",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8450), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8451) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT007",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8453), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8454) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT008",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8456), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT009",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8461), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8461) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT010",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8464), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8464) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT011",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8467), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT012",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8470), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT013",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8473), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8473) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT014",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8475), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8476) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: "ACT015",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8478), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8479) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C001",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7423), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7424) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C002",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7427), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C003",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7431), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7431) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: "C004",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7434), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7434) });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "02a68641-d679-4fb4-83d9-8562c67893f3", "C004", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8613), 35.0, "P011", 2 },
                    { "03e82f23-caaa-4c9c-967b-937f48a11ef5", "C004", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8562), 120.0, "P010", 1 },
                    { "27be0b9c-6a44-46a8-aca9-1e78b77b03e0", "C001", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8529), 80.0, "P003", 1 },
                    { "54f93316-4e66-487e-b5ed-488bc18e940f", "C002", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8543), 40.0, "P006", 2 },
                    { "557ba127-a458-44be-bb66-8901568d3df0", "C004", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8618), 45.0, "P012", 1 },
                    { "5f31bc63-ad5d-4639-b8b0-8f5af0fec222", "C002", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8533), 100.0, "P004", 1 },
                    { "675bb42d-3502-4026-9916-fc1e163833ac", "C001", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8520), 30.0, "P001", 2 },
                    { "861aa832-a880-4f8c-9cc8-d268dccfa894", "C003", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8547), 15.0, "P007", 5 },
                    { "8d54efc2-74b6-46ec-91fa-bf2c86a67f91", "C001", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8525), 20.0, "P002", 1 },
                    { "9c963262-a59a-4ba1-a9ad-67b8d8e3da02", "C003", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8558), 60.0, "P009", 1 },
                    { "9f10280c-6679-42b8-8ea1-805a9bd6c9f6", "C002", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8539), 25.0, "P005", 3 },
                    { "a03b863d-97b0-4fd0-b290-7a2c0d560433", "C003", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8552), 50.0, "P008", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6374));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6399));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "CH015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "CharacterImage",
                keyColumn: "CharacterImageId",
                keyValue: "CI015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "E012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8138));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "EventActivity",
                keyColumn: "EventActivityId",
                keyValue: "EA015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "EventCharacter",
                keyColumn: "EventCharacterId",
                keyValue: "EC012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "EventImage",
                keyColumn: "ImageId",
                keyValue: "EI012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "2cb203b0-09b9-4026-83aa-34f8942e2a20", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null, null },
                    { "38f04035-b758-40c4-843f-5423f301550d", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null, null },
                    { "3d231a5d-e994-440e-87c3-8f124988956a", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null, null },
                    { "87c9e20a-b129-43b3-9260-be4b894aa80c", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null, null },
                    { "a71a91ad-fb14-4c2a-9af7-dcf4f526a2ab", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null, null },
                    { "cdb4f416-6424-4a33-87f8-0c7cb2e8f5b3", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null, null },
                    { "ce85c47e-7d2d-43fa-a8b9-93bbf1e52a21", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null, null },
                    { "d1f44910-02a7-4b9c-af99-06406facb62d", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null, null },
                    { "fabe0010-c374-4837-ace4-39c3935b4a36", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N001",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N002",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N003",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N004",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N005",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N006",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N007",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N008",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N009",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N010",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N011",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N012",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N013",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N014",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: "N015",
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0394db0e-f4b6-4f86-98bc-b417e257a584", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8962), "O014", 45.0, "P012", 3 },
                    { "065fc389-bda8-4f4f-8db7-3438dc7b2c79", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8958), "O013", 35.0, "P011", 2 },
                    { "080d9050-7d82-4274-a754-6c1628e383f5", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8941), "O011", 15.0, "P007", 4 },
                    { "2243dec9-10ff-4a96-80ca-788dbc0fc028", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8892), "O005", 120.0, "P010", 1 },
                    { "22904066-0308-4f25-9caa-2a3fc5db52d0", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8876), "O003", 40.0, "P006", 3 },
                    { "2ef18de8-9578-45ad-8778-c4cfe7ce5ba2", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8880), "O004", 15.0, "P007", 4 },
                    { "34263154-2815-4954-9961-94201f6dd273", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8951), "O012", 60.0, "P009", 1 },
                    { "36139027-492b-4604-8352-4cdada6aa389", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8955), "O013", 120.0, "P010", 1 },
                    { "37d91ba7-d897-404e-b830-f7b116b12655", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8909), "O007", 90.0, "P014", 2 },
                    { "41c09ac6-5471-4e06-9dfb-f7ef2b04156f", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8905), "O007", 18.0, "P013", 5 },
                    { "4d44eeaa-a5ba-42ca-8aa0-37206af96eea", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8896), "O006", 35.0, "P011", 2 },
                    { "4de01af4-f413-4c46-a086-2a87e0a7e01e", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8862), "O002", 80.0, "P003", 1 },
                    { "5a59eddb-9d65-4f75-8c70-96e78bac3006", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8805), "O001", 30.0, "P001", 3 },
                    { "638d4cab-7942-4bcf-911a-897b388612e4", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8925), "O009", 80.0, "P003", 2 },
                    { "6d8ebf6e-3104-4102-812e-a772b1e843cf", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8873), "O003", 25.0, "P005", 2 },
                    { "71e4c668-5d61-49b8-be58-a1024f389b71", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8971), "O015", 90.0, "P014", 2 },
                    { "7fe34eb5-62cb-492f-83cc-4f2dc3c8ab1d", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8912), "O008", 22.0, "P015", 4 },
                    { "8040a53d-83f2-4cd6-9c7d-b112b0de63b4", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8934), "O010", 25.0, "P005", 3 },
                    { "82592c57-406c-4124-9b49-3feb8bc7e984", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8901), "O006", 45.0, "P012", 3 },
                    { "886160e0-ebc2-430c-97e0-4a73370dbb2b", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8889), "O005", 60.0, "P009", 1 },
                    { "8b4f1d5e-58ca-4a46-ba29-c584a04f1591", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8810), "O001", 20.0, "P002", 5 },
                    { "91fced00-33d0-4538-be2f-0e9dcfd06cfa", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8968), "O014", 18.0, "P013", 5 },
                    { "a4778ce3-8483-47a9-b767-b92fedbba744", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8885), "O004", 50.0, "P008", 2 },
                    { "ae6fe6c1-73be-46d6-84ea-b8680ee73e11", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8975), "O015", 22.0, "P015", 4 },
                    { "b61f75ca-4220-431f-be67-c5ee6eeb47ac", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8929), "O010", 100.0, "P004", 1 },
                    { "c1c00e55-e55c-4f7b-8e62-56c35ffae338", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8945), "O012", 50.0, "P008", 2 },
                    { "d267b501-309a-4a49-b5da-e79d1737878f", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8869), "O002", 100.0, "P004", 1 },
                    { "d8a9af63-f395-4fa3-8119-c2aeb7a3083f", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8938), "O011", 40.0, "P006", 2 },
                    { "f28aab82-4c5f-4794-80bf-f4938e324b1b", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8918), "O008", 30.0, "P001", 1 },
                    { "fbbf2846-eae5-41cb-8ba1-64ba09c67cf3", new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(8922), "O009", 20.0, "P002", 6 }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "P015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG004",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG005",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG006",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG007",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG008",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG009",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG010",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG011",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG012",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG013",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG014",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "ProductImageId",
                keyValue: "IMG015",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC01",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9223), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC02",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9229), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC03",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9233), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9234) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC04",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9237), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC05",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9289), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC06",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9294), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9294) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC07",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9297), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC08",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9300), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC09",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9304), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC10",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9307), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC11",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9310), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC12",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9314), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9314) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC13",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9320), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC14",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9323), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9324) });

            migrationBuilder.UpdateData(
                table: "RequestCharacter",
                keyColumn: "RequestCharacterId",
                keyValue: "RC15",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9327), new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(9327) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S001",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S002",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: "S003",
                column: "CreateDate",
                value: new DateTime(2025, 3, 30, 14, 0, 49, 374, DateTimeKind.Utc).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T001",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7639), new DateTime(2025, 4, 2, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7637), new DateTime(2025, 4, 1, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7625), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7640) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T002",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7648), new DateTime(2025, 4, 4, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7647), new DateTime(2025, 4, 3, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7646), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7648) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T003",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7653), new DateTime(2025, 4, 6, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7652), new DateTime(2025, 4, 5, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7652), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7654) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T004",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7661), new DateTime(2025, 3, 31, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7660), new DateTime(2025, 3, 31, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7659), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7661) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T005",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7666), new DateTime(2025, 4, 8, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7665), new DateTime(2025, 4, 7, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7665), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7667) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T006",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7671), new DateTime(2025, 4, 10, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7671), new DateTime(2025, 4, 9, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7670), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T007",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7677), new DateTime(2025, 4, 12, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7676), new DateTime(2025, 4, 11, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7675), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7677) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T008",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7682), new DateTime(2025, 4, 14, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7681), new DateTime(2025, 4, 13, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7680), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T009",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7688), new DateTime(2025, 4, 16, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7688), new DateTime(2025, 4, 15, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7687), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T010",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7694), new DateTime(2025, 4, 18, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7693), new DateTime(2025, 4, 17, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7692), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7694) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T011",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7699), new DateTime(2025, 4, 20, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7698), new DateTime(2025, 4, 19, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7697), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7699) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "T012",
                columns: new[] { "CreateDate", "EndDate", "StartDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7706), new DateTime(2025, 4, 22, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7705), new DateTime(2025, 4, 21, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7704), new DateTime(2025, 3, 30, 21, 0, 49, 374, DateTimeKind.Local).AddTicks(7706) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "02a68641-d679-4fb4-83d9-8562c67893f3");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "03e82f23-caaa-4c9c-967b-937f48a11ef5");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "27be0b9c-6a44-46a8-aca9-1e78b77b03e0");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "54f93316-4e66-487e-b5ed-488bc18e940f");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "557ba127-a458-44be-bb66-8901568d3df0");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "5f31bc63-ad5d-4639-b8b0-8f5af0fec222");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "675bb42d-3502-4026-9916-fc1e163833ac");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "861aa832-a880-4f8c-9cc8-d268dccfa894");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "8d54efc2-74b6-46ec-91fa-bf2c86a67f91");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "9c963262-a59a-4ba1-a9ad-67b8d8e3da02");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "9f10280c-6679-42b8-8ea1-805a9bd6c9f6");

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "CartProductId",
                keyValue: "a03b863d-97b0-4fd0-b290-7a2c0d560433");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "2cb203b0-09b9-4026-83aa-34f8942e2a20");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "38f04035-b758-40c4-843f-5423f301550d");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "3d231a5d-e994-440e-87c3-8f124988956a");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "87c9e20a-b129-43b3-9260-be4b894aa80c");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "a71a91ad-fb14-4c2a-9af7-dcf4f526a2ab");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "cdb4f416-6424-4a33-87f8-0c7cb2e8f5b3");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "ce85c47e-7d2d-43fa-a8b9-93bbf1e52a21");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "d1f44910-02a7-4b9c-af99-06406facb62d");

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "fabe0010-c374-4837-ace4-39c3935b4a36");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "0394db0e-f4b6-4f86-98bc-b417e257a584");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "065fc389-bda8-4f4f-8db7-3438dc7b2c79");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "080d9050-7d82-4274-a754-6c1628e383f5");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2243dec9-10ff-4a96-80ca-788dbc0fc028");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "22904066-0308-4f25-9caa-2a3fc5db52d0");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "2ef18de8-9578-45ad-8778-c4cfe7ce5ba2");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "34263154-2815-4954-9961-94201f6dd273");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "36139027-492b-4604-8352-4cdada6aa389");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "37d91ba7-d897-404e-b830-f7b116b12655");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "41c09ac6-5471-4e06-9dfb-f7ef2b04156f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "4d44eeaa-a5ba-42ca-8aa0-37206af96eea");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "4de01af4-f413-4c46-a086-2a87e0a7e01e");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "5a59eddb-9d65-4f75-8c70-96e78bac3006");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "638d4cab-7942-4bcf-911a-897b388612e4");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "6d8ebf6e-3104-4102-812e-a772b1e843cf");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "71e4c668-5d61-49b8-be58-a1024f389b71");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "7fe34eb5-62cb-492f-83cc-4f2dc3c8ab1d");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "8040a53d-83f2-4cd6-9c7d-b112b0de63b4");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "82592c57-406c-4124-9b49-3feb8bc7e984");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "886160e0-ebc2-430c-97e0-4a73370dbb2b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "8b4f1d5e-58ca-4a46-ba29-c584a04f1591");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "91fced00-33d0-4538-be2f-0e9dcfd06cfa");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "a4778ce3-8483-47a9-b767-b92fedbba744");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "ae6fe6c1-73be-46d6-84ea-b8680ee73e11");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "b61f75ca-4220-431f-be67-c5ee6eeb47ac");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "c1c00e55-e55c-4f7b-8e62-56c35ffae338");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "d267b501-309a-4a49-b5da-e79d1737878f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "d8a9af63-f395-4fa3-8119-c2aeb7a3083f");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "f28aab82-4c5f-4794-80bf-f4938e324b1b");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: "fbbf2846-eae5-41cb-8ba1-64ba09c67cf3");

            migrationBuilder.DropColumn(
                name: "GoogleId",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
