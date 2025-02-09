using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class CCSS_Migration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "Account",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    RefreshTokenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "account1",
                columns: new[] { "Code", "CreateDate", "Password" },
                values: new object[] { "123456", new DateTime(2025, 2, 9, 2, 52, 0, 310, DateTimeKind.Utc).AddTicks(8446), "$2a$11$ib7P2NnPeRgkLa6kv77Up.4HJTzqugjUysVwbnSjZr1kSWDQOiOQm" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "account2",
                columns: new[] { "Code", "CreateDate", "Password" },
                values: new object[] { "123456", new DateTime(2025, 2, 9, 2, 52, 0, 451, DateTimeKind.Utc).AddTicks(4417), "$2a$11$lX0sTBSkpLu3ek2Iajf6jONX9qp2/gDmKpxJaWCD3bK0d/U.zJMem" });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "character1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4275));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "character2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Contract",
                keyColumn: "ContractId",
                keyValue: "contract1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Contract",
                keyColumn: "ContractId",
                keyValue: "contract2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "event1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "event2",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4334), new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "EventCategory",
                keyColumn: "EventCategoryId",
                keyValue: "eventcategory1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "EventCategory",
                keyColumn: "EventCategoryId",
                keyValue: "eventcategory2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "feedback1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "feedback2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: "image1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: "image2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: "image3",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: "image4",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: "payment1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: "payment2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "task1",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(3991), new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "task2",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4036), new DateTime(2025, 2, 9, 2, 52, 0, 600, DateTimeKind.Utc).AddTicks(4037) });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "account1",
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2025, 2, 8, 9, 57, 39, 936, DateTimeKind.Utc).AddTicks(8141), "$2a$11$pwYMx3B/cQ1gqUfdXWWDwePJR3Z61S4evCMSegbd.x4ZXP0tquzji" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "account2",
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2025, 2, 8, 9, 57, 40, 62, DateTimeKind.Utc).AddTicks(7068), "$2a$11$mVJVBp4KkdxnK9DstzSuxuixNj0.b54OO4O4grG.3SnNJ/CX587Fm" });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "character1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8412));

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: "character2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "Contract",
                keyColumn: "ContractId",
                keyValue: "contract1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "Contract",
                keyColumn: "ContractId",
                keyValue: "contract2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "event1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: "event2",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8632), new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8632) });

            migrationBuilder.UpdateData(
                table: "EventCategory",
                keyColumn: "EventCategoryId",
                keyValue: "eventcategory1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "EventCategory",
                keyColumn: "EventCategoryId",
                keyValue: "eventcategory2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "feedback1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "FeedbackId",
                keyValue: "feedback2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: "image1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: "image2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: "image3",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: "image4",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: "payment1",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: "payment2",
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "task1",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(6739), new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: "task2",
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(6761), new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8016) });
        }
    }
}
