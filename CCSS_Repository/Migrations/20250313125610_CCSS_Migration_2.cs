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
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "EventCharacter",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventCharacter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "EventCharacter",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "EventCharacter");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventCharacter");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "EventCharacter");
        }
    }
}
