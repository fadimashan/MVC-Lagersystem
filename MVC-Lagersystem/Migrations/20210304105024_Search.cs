using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Lagersystem.Migrations
{
    public partial class Search : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Search",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Search",
                table: "Product");
        }
    }
}
