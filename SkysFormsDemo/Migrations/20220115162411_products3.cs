using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkysFormsDemo.Migrations
{
    public partial class products3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ean13",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ean13",
                table: "Products");
        }
    }
}
