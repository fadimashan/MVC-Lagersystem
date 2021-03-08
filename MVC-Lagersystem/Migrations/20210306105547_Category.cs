using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Lagersystem.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Search",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ProductViewModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ProductViewModels");

            migrationBuilder.AddColumn<string>(
                name: "Search",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
