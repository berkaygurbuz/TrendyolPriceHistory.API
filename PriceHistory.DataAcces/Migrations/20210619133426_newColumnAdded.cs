using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceHistory.DataAcces.Migrations
{
    public partial class newColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "Products");
        }
    }
}
