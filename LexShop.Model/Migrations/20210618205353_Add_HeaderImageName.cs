using Microsoft.EntityFrameworkCore.Migrations;

namespace LexShop.Model.Migrations
{
    public partial class Add_HeaderImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeaderImageName",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeaderImageName",
                table: "Category");
        }
    }
}
