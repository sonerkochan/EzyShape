using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    public partial class SplitAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Category_CategoryId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Equipment_EquipmentId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Level_LevelId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Muscle_MuscleId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Muscle",
                table: "Muscle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Level",
                table: "Level");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Muscle",
                newName: "Muscles");

            migrationBuilder.RenameTable(
                name: "Level",
                newName: "Levels");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "SplitId",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Muscles",
                table: "Muscles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Levels",
                table: "Levels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Splits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Splits", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "c4b24d44-7a0d-421b-a539-12f52c6bda48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "b0d6bb39-1e99-49c0-add8-8d7f6464f983");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_SplitId",
                table: "Workouts",
                column: "SplitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Categories_CategoryId",
                table: "Exercises",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Equipments_EquipmentId",
                table: "Exercises",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Levels_LevelId",
                table: "Exercises",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Muscles_MuscleId",
                table: "Exercises",
                column: "MuscleId",
                principalTable: "Muscles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Splits_SplitId",
                table: "Workouts",
                column: "SplitId",
                principalTable: "Splits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Categories_CategoryId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Equipments_EquipmentId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Levels_LevelId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Muscles_MuscleId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Splits_SplitId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "Splits");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_SplitId",
                table: "Workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Muscles",
                table: "Muscles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Levels",
                table: "Levels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SplitId",
                table: "Workouts");

            migrationBuilder.RenameTable(
                name: "Muscles",
                newName: "Muscle");

            migrationBuilder.RenameTable(
                name: "Levels",
                newName: "Level");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Muscle",
                table: "Muscle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Level",
                table: "Level",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "59b5658f-9e52-422e-9eda-99e16eb498ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "d19b56c6-d5c8-4f52-93d3-43a8e376c3a9");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Category_CategoryId",
                table: "Exercises",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Equipment_EquipmentId",
                table: "Exercises",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Level_LevelId",
                table: "Exercises",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Muscle_MuscleId",
                table: "Exercises",
                column: "MuscleId",
                principalTable: "Muscle",
                principalColumn: "Id");
        }
    }
}
