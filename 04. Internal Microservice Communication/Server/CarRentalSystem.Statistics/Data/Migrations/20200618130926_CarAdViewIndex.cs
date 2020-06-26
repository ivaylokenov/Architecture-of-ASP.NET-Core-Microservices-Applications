using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Statistics.Data.Migrations
{
    public partial class CarAdViewIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarAdViews_CarAdId",
                table: "CarAdViews",
                column: "CarAdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarAdViews_CarAdId",
                table: "CarAdViews");
        }
    }
}
