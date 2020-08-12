using Microsoft.EntityFrameworkCore.Migrations;

namespace FitBody.DataBase.Migrations
{
    public partial class DatabaseModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "context",
                table: "threads");

            migrationBuilder.DropColumn(
                name: "content",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "content",
                table: "subcategories");

            migrationBuilder.DropColumn(
                name: "foreign_id",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "title",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "type",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "content",
                table: "categories");

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "threads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content",
                table: "threads");

            migrationBuilder.AddColumn<string>(
                name: "context",
                table: "threads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "subcategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "foreign_id",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
