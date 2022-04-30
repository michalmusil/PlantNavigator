using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNavigator.API.Migrations
{
    public partial class NameErrorsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FertilizingHabit_FertilizerType_FertilizerType_FertilizerTypeId",
                table: "FertilizingHabit_FertilizerType");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizingHabit_FertilizerType_FertilizingHabit_FertilizingHabitId",
                table: "FertilizingHabit_FertilizerType");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Classification_Classification_ClassificationId",
                table: "Plant_Classification");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Disease_Disease_DiseaseId",
                table: "Plant_Disease");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_FertilizingHabit_FertilizingHabit_FertilizingHabitId",
                table: "Plant_FertilizingHabit");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Pest_Pest_PestId",
                table: "Plant_Pest");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_WateringHabit_WateringHabit_WateringHabitId",
                table: "Plant_WateringHabit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WateringHabit",
                table: "WateringHabit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pest",
                table: "Pest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FertilizingHabit",
                table: "FertilizingHabit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FertilizerType",
                table: "FertilizerType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disease",
                table: "Disease");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classification",
                table: "Classification");

            migrationBuilder.RenameTable(
                name: "WateringHabit",
                newName: "WateringHabits");

            migrationBuilder.RenameTable(
                name: "Pest",
                newName: "Pests");

            migrationBuilder.RenameTable(
                name: "FertilizingHabit",
                newName: "FertilizingHabits");

            migrationBuilder.RenameTable(
                name: "FertilizerType",
                newName: "FertilizerTypes");

            migrationBuilder.RenameTable(
                name: "Disease",
                newName: "Diseases");

            migrationBuilder.RenameTable(
                name: "Classification",
                newName: "Classifications");

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "Plant_Disease",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WateringHabits",
                table: "WateringHabits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pests",
                table: "Pests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FertilizingHabits",
                table: "FertilizingHabits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FertilizerTypes",
                table: "FertilizerTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diseases",
                table: "Diseases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizingHabit_FertilizerType_FertilizerTypes_FertilizerTypeId",
                table: "FertilizingHabit_FertilizerType",
                column: "FertilizerTypeId",
                principalTable: "FertilizerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizingHabit_FertilizerType_FertilizingHabits_FertilizingHabitId",
                table: "FertilizingHabit_FertilizerType",
                column: "FertilizingHabitId",
                principalTable: "FertilizingHabits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Classification_Classifications_ClassificationId",
                table: "Plant_Classification",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Disease_Diseases_DiseaseId",
                table: "Plant_Disease",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_FertilizingHabit_FertilizingHabits_FertilizingHabitId",
                table: "Plant_FertilizingHabit",
                column: "FertilizingHabitId",
                principalTable: "FertilizingHabits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Pest_Pests_PestId",
                table: "Plant_Pest",
                column: "PestId",
                principalTable: "Pests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_WateringHabit_WateringHabits_WateringHabitId",
                table: "Plant_WateringHabit",
                column: "WateringHabitId",
                principalTable: "WateringHabits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FertilizingHabit_FertilizerType_FertilizerTypes_FertilizerTypeId",
                table: "FertilizingHabit_FertilizerType");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizingHabit_FertilizerType_FertilizingHabits_FertilizingHabitId",
                table: "FertilizingHabit_FertilizerType");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Classification_Classifications_ClassificationId",
                table: "Plant_Classification");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Disease_Diseases_DiseaseId",
                table: "Plant_Disease");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_FertilizingHabit_FertilizingHabits_FertilizingHabitId",
                table: "Plant_FertilizingHabit");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Pest_Pests_PestId",
                table: "Plant_Pest");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_WateringHabit_WateringHabits_WateringHabitId",
                table: "Plant_WateringHabit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WateringHabits",
                table: "WateringHabits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pests",
                table: "Pests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FertilizingHabits",
                table: "FertilizingHabits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FertilizerTypes",
                table: "FertilizerTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diseases",
                table: "Diseases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications");

            migrationBuilder.RenameTable(
                name: "WateringHabits",
                newName: "WateringHabit");

            migrationBuilder.RenameTable(
                name: "Pests",
                newName: "Pest");

            migrationBuilder.RenameTable(
                name: "FertilizingHabits",
                newName: "FertilizingHabit");

            migrationBuilder.RenameTable(
                name: "FertilizerTypes",
                newName: "FertilizerType");

            migrationBuilder.RenameTable(
                name: "Diseases",
                newName: "Disease");

            migrationBuilder.RenameTable(
                name: "Classifications",
                newName: "Classification");

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "Plant_Disease",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WateringHabit",
                table: "WateringHabit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pest",
                table: "Pest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FertilizingHabit",
                table: "FertilizingHabit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FertilizerType",
                table: "FertilizerType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disease",
                table: "Disease",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classification",
                table: "Classification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizingHabit_FertilizerType_FertilizerType_FertilizerTypeId",
                table: "FertilizingHabit_FertilizerType",
                column: "FertilizerTypeId",
                principalTable: "FertilizerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizingHabit_FertilizerType_FertilizingHabit_FertilizingHabitId",
                table: "FertilizingHabit_FertilizerType",
                column: "FertilizingHabitId",
                principalTable: "FertilizingHabit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Classification_Classification_ClassificationId",
                table: "Plant_Classification",
                column: "ClassificationId",
                principalTable: "Classification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Disease_Disease_DiseaseId",
                table: "Plant_Disease",
                column: "DiseaseId",
                principalTable: "Disease",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_FertilizingHabit_FertilizingHabit_FertilizingHabitId",
                table: "Plant_FertilizingHabit",
                column: "FertilizingHabitId",
                principalTable: "FertilizingHabit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Pest_Pest_PestId",
                table: "Plant_Pest",
                column: "PestId",
                principalTable: "Pest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_WateringHabit_WateringHabit_WateringHabitId",
                table: "Plant_WateringHabit",
                column: "WateringHabitId",
                principalTable: "WateringHabit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
