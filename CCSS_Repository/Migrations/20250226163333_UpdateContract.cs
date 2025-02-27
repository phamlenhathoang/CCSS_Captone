using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc1",
                column: "Password",
                value: "$2a$11$UUWTgEVuSu/WTixjyRQCNOk70VsfWpBSaOjVp/yzj9uHqE5KZEldK");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc2",
                column: "Password",
                value: "$2a$11$c6/YXePSNrZvmNP6Vh5Wbu7alLi0hzIy3upEPqKkU2n4KHRG4bg9W");

            migrationBuilder.UpdateData(
                table: "Contract",
                keyColumn: "ContractId",
                keyValue: "ctr1",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contract",
                keyColumn: "ContractId",
                keyValue: "ctr2",
                column: "ImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Contract");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc1",
                column: "Password",
                value: "$2a$11$apXEBF6Fn2.5tFMpLxuRLesqJtjTDEJ5IX39W/u/22ZviOmHwrbh2");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: "acc2",
                column: "Password",
                value: "$2a$11$jKXAa90/7MBppoU6EZ93Xu6Ao.zQO7L3sJMdAbhGLuyrQtiKs7Xa6");
        }
    }
}
