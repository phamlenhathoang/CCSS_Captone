using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class CCSS_Migration_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_TicketAccounts_TicketAccountId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAccounts_Account_AccountId",
                table: "TicketAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAccounts_Ticket_TicketId",
                table: "TicketAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketAccounts",
                table: "TicketAccounts");

            migrationBuilder.RenameTable(
                name: "TicketAccounts",
                newName: "TicketAccount");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAccounts_TicketId",
                table: "TicketAccount",
                newName: "IX_TicketAccount_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAccounts_AccountId",
                table: "TicketAccount",
                newName: "IX_TicketAccount_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketAccount",
                table: "TicketAccount",
                column: "TicketAccountId");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc1",
                column: "Password",
                value: "CR044vTz0E1+p6akfbtyoA==");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc2",
                column: "Password",
                value: "CR044vTz0E1+p6akfbtyoA==");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_TicketAccount_TicketAccountId",
                table: "Payment",
                column: "TicketAccountId",
                principalTable: "TicketAccount",
                principalColumn: "TicketAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAccount_Account_AccountId",
                table: "TicketAccount",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAccount_Ticket_TicketId",
                table: "TicketAccount",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_TicketAccount_TicketAccountId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAccount_Account_AccountId",
                table: "TicketAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAccount_Ticket_TicketId",
                table: "TicketAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketAccount",
                table: "TicketAccount");

            migrationBuilder.RenameTable(
                name: "TicketAccount",
                newName: "TicketAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAccount_TicketId",
                table: "TicketAccounts",
                newName: "IX_TicketAccounts_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAccount_AccountId",
                table: "TicketAccounts",
                newName: "IX_TicketAccounts_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketAccounts",
                table: "TicketAccounts",
                column: "TicketAccountId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_TicketAccounts_TicketAccountId",
                table: "Payment",
                column: "TicketAccountId",
                principalTable: "TicketAccounts",
                principalColumn: "TicketAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAccounts_Account_AccountId",
                table: "TicketAccounts",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAccounts_Ticket_TicketId",
                table: "TicketAccounts",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId");
        }
    }
}
