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
            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc1",
                column: "Password",
                value: "$2a$11$WIowXxKY9Pgrlc0UgXYcgecfWAIQqjlQDFQh/q262j57FNYuX6iKO");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc2",
                column: "Password",
                value: "$2a$11$XFNiaVMLdyw.ZHF1thasEeBg1llakPp0.dducSAR3u1ePqV8gpYBi");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc1",
                column: "Password",
                value: "$2a$11$wbbM8zoTEeIXs33wVQLYf.5jXmnOYbJLIxNXXcANhAubWoD8H5hsS");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc2",
                column: "Password",
                value: "$2a$11$mMnD2U8Ylf2sXKakbghlcuzh5m3efUWGqVWfSVbkFvmjC/w.g7MSi");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");
        }
    }
}
