using Microsoft.EntityFrameworkCore.Migrations;

namespace Retail.DataAccess.Migrations
{
    public partial class retailv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Debt",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debt",
                table: "Orders");
        }
    }
}
