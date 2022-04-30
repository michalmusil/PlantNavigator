using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNavigator.API.Migrations
{
    public partial class PlantNavigatorDatabaseInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LightConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Intensity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Intensity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WaterConditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_WaterConditions_WaterConditionId",
                        column: x => x.WaterConditionId,
                        principalTable: "WaterConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants_Soils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    SoilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants_Soils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Soils_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Soils_Soils_SoilId",
                        column: x => x.SoilId,
                        principalTable: "Soils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_WaterConditionId",
                table: "Plants",
                column: "WaterConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Soils_PlantId",
                table: "Plants_Soils",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Soils_SoilId",
                table: "Plants_Soils",
                column: "SoilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LightConditions");

            migrationBuilder.DropTable(
                name: "Plants_Soils");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Soils");

            migrationBuilder.DropTable(
                name: "WaterConditions");
        }
    }
}
