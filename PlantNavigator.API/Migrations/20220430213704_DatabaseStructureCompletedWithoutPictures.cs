using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNavigator.API.Migrations
{
    public partial class DatabaseStructureCompletedWithoutPictures : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "FloweringFrom",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloweringTo",
                table: "Plants",
                type: "int",
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
                name: "Classifications",
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
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizingHabits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysFrequency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeFrom = table.Column<int>(type: "int", nullable: true),
                    TimeTo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizingHabits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WateringHabits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysFrequency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeFrom = table.Column<int>(type: "int", nullable: true),
                    TimeTo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WateringHabits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants_Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    ClassificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants_Classifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Classifications_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Classifications_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants_Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants_Diseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Diseases_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Diseases_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FertilizingHabits_FertilizerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FertilizingHabitId = table.Column<int>(type: "int", nullable: false),
                    FertilizerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizingHabits_FertilizerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizingHabits_FertilizerTypes_FertilizerTypes_FertilizerTypeId",
                        column: x => x.FertilizerTypeId,
                        principalTable: "FertilizerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizingHabits_FertilizerTypes_FertilizingHabits_FertilizingHabitId",
                        column: x => x.FertilizingHabitId,
                        principalTable: "FertilizingHabits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants_FertilizingHabits",
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
                    table.PrimaryKey("PK_Plants_FertilizingHabits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_FertilizingHabits_FertilizingHabits_FertilizingHabitId",
                        column: x => x.FertilizingHabitId,
                        principalTable: "FertilizingHabits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_FertilizingHabits_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants_Pests",
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
                    table.PrimaryKey("PK_Plants_Pests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Pests_Pests_PestId",
                        column: x => x.PestId,
                        principalTable: "Pests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Pests_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants_WateringHabits",
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
                    table.PrimaryKey("PK_Plants_WateringHabits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_WateringHabits_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_WateringHabits_WateringHabits_WateringHabitId",
                        column: x => x.WateringHabitId,
                        principalTable: "WateringHabits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_LightConditionId",
                table: "Plants",
                column: "LightConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizingHabits_FertilizerTypes_FertilizerTypeId",
                table: "FertilizingHabits_FertilizerTypes",
                column: "FertilizerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizingHabits_FertilizerTypes_FertilizingHabitId",
                table: "FertilizingHabits_FertilizerTypes",
                column: "FertilizingHabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Classifications_ClassificationId",
                table: "Plants_Classifications",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Classifications_PlantId",
                table: "Plants_Classifications",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Diseases_DiseaseId",
                table: "Plants_Diseases",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Diseases_PlantId",
                table: "Plants_Diseases",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_FertilizingHabits_FertilizingHabitId",
                table: "Plants_FertilizingHabits",
                column: "FertilizingHabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_FertilizingHabits_PlantId",
                table: "Plants_FertilizingHabits",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Pests_PestId",
                table: "Plants_Pests",
                column: "PestId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Pests_PlantId",
                table: "Plants_Pests",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_WateringHabits_PlantId",
                table: "Plants_WateringHabits",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_WateringHabits_WateringHabitId",
                table: "Plants_WateringHabits",
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
                name: "FertilizingHabits_FertilizerTypes");

            migrationBuilder.DropTable(
                name: "Plants_Classifications");

            migrationBuilder.DropTable(
                name: "Plants_Diseases");

            migrationBuilder.DropTable(
                name: "Plants_FertilizingHabits");

            migrationBuilder.DropTable(
                name: "Plants_Pests");

            migrationBuilder.DropTable(
                name: "Plants_WateringHabits");

            migrationBuilder.DropTable(
                name: "FertilizerTypes");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "FertilizingHabits");

            migrationBuilder.DropTable(
                name: "Pests");

            migrationBuilder.DropTable(
                name: "WateringHabits");

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
