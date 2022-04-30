using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNavigator.API.Migrations
{
    public partial class AllEntitiesButPicturesImplemented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_WaterConditions_WaterConditionId",
                table: "Plants");

            migrationBuilder.AlterColumn<int>(
                name: "WaterConditionId",
                table: "Plants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FloweringFrom",
                table: "Plants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FloweringTo",
                table: "Plants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LightConditionId",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MistingAppropriate",
                table: "Plants",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassificationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizingHabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysFrequency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizingHabit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WateringHabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysFrequency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WateringHabit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plant_Classification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    ClassificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant_Classification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_Classification_Classification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plant_Classification_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plant_Disease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant_Disease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_Disease_Disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Disease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plant_Disease_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FertilizingHabit_FertilizerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FertilizingHabitId = table.Column<int>(type: "int", nullable: false),
                    FertilizerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizingHabit_FertilizerType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizingHabit_FertilizerType_FertilizerType_FertilizerTypeId",
                        column: x => x.FertilizerTypeId,
                        principalTable: "FertilizerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizingHabit_FertilizerType_FertilizingHabit_FertilizingHabitId",
                        column: x => x.FertilizingHabitId,
                        principalTable: "FertilizingHabit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plant_FertilizingHabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    FertilizingHabitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant_FertilizingHabit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_FertilizingHabit_FertilizingHabit_FertilizingHabitId",
                        column: x => x.FertilizingHabitId,
                        principalTable: "FertilizingHabit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plant_FertilizingHabit_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plant_Pest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    PestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant_Pest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_Pest_Pest_PestId",
                        column: x => x.PestId,
                        principalTable: "Pest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plant_Pest_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plant_WateringHabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    WateringHabitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant_WateringHabit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_WateringHabit_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plant_WateringHabit_WateringHabit_WateringHabitId",
                        column: x => x.WateringHabitId,
                        principalTable: "WateringHabit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_LightConditionId",
                table: "Plants",
                column: "LightConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizingHabit_FertilizerType_FertilizerTypeId",
                table: "FertilizingHabit_FertilizerType",
                column: "FertilizerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizingHabit_FertilizerType_FertilizingHabitId",
                table: "FertilizingHabit_FertilizerType",
                column: "FertilizingHabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_Classification_ClassificationId",
                table: "Plant_Classification",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_Classification_PlantId",
                table: "Plant_Classification",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_Disease_DiseaseId",
                table: "Plant_Disease",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_Disease_PlantId",
                table: "Plant_Disease",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_FertilizingHabit_FertilizingHabitId",
                table: "Plant_FertilizingHabit",
                column: "FertilizingHabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_FertilizingHabit_PlantId",
                table: "Plant_FertilizingHabit",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_Pest_PestId",
                table: "Plant_Pest",
                column: "PestId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_Pest_PlantId",
                table: "Plant_Pest",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_WateringHabit_PlantId",
                table: "Plant_WateringHabit",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_WateringHabit_WateringHabitId",
                table: "Plant_WateringHabit",
                column: "WateringHabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_LightConditions_LightConditionId",
                table: "Plants",
                column: "LightConditionId",
                principalTable: "LightConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_WaterConditions_WaterConditionId",
                table: "Plants",
                column: "WaterConditionId",
                principalTable: "WaterConditions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_LightConditions_LightConditionId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_WaterConditions_WaterConditionId",
                table: "Plants");

            migrationBuilder.DropTable(
                name: "FertilizingHabit_FertilizerType");

            migrationBuilder.DropTable(
                name: "Plant_Classification");

            migrationBuilder.DropTable(
                name: "Plant_Disease");

            migrationBuilder.DropTable(
                name: "Plant_FertilizingHabit");

            migrationBuilder.DropTable(
                name: "Plant_Pest");

            migrationBuilder.DropTable(
                name: "Plant_WateringHabit");

            migrationBuilder.DropTable(
                name: "FertilizerType");

            migrationBuilder.DropTable(
                name: "Classification");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropTable(
                name: "FertilizingHabit");

            migrationBuilder.DropTable(
                name: "Pest");

            migrationBuilder.DropTable(
                name: "WateringHabit");

            migrationBuilder.DropIndex(
                name: "IX_Plants_LightConditionId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "FloweringFrom",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "FloweringTo",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "LightConditionId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "MistingAppropriate",
                table: "Plants");

            migrationBuilder.AlterColumn<int>(
                name: "WaterConditionId",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_WaterConditions_WaterConditionId",
                table: "Plants",
                column: "WaterConditionId",
                principalTable: "WaterConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
