using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceHistory.DataAcces.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceHistorys",
                columns: table => new
                {
                    PriceHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistorys", x => x.PriceHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    linkUrl = table.Column<string>(nullable: true),
                    brand = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    isApprove = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceHistorys");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
