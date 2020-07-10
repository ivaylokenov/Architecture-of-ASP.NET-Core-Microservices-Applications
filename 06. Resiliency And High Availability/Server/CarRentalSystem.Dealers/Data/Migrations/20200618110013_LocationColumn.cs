using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Dealers.Data.Migrations
{
    public partial class LocationColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "CarAds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "CarAds");
        }
    }
}
