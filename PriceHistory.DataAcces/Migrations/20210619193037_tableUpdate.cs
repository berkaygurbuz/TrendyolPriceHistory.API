using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceHistory.DataAcces.Migrations
{
    public partial class tableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceHistorys",
                table: "PriceHistorys");

            migrationBuilder.DropColumn(
                name: "PriceHistoryId",
                table: "PriceHistorys");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PriceHistorys",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceHistorys",
                table: "PriceHistorys",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceHistorys",
                table: "PriceHistorys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PriceHistorys");

            migrationBuilder.AddColumn<int>(
                name: "PriceHistoryId",
                table: "PriceHistorys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceHistorys",
                table: "PriceHistorys",
                column: "PriceHistoryId");
        }
    }
}
