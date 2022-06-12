using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNavigator.API.Migrations
{
    public partial class AddedTemperatureRangeToPlants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemperatureFrom",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureTo",
                table: "Plants",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemperatureFrom",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "TemperatureTo",
                table: "Plants");
        }
    }
}
