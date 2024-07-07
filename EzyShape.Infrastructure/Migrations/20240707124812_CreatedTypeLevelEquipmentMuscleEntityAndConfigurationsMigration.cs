using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    public partial class CreatedTypeLevelEquipmentMuscleEntityAndConfigurationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "PrimaryMuscle",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "SecondaryMuscle",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuscleId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muscle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscle", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "6fa28154-7edc-4d70-9210-67ec69169981");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "12ffa65c-011d-4de0-b1c7-f961ed33dce1");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cardio" },
                    { 2, "Olympic Weightlifting" },
                    { 3, "Plyometrics" },
                    { 4, "Powerlifting" },
                    { 5, "Strength" },
                    { 6, "Strongman" },
                    { 7, "Stretching" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "No Equipment" },
                    { 2, "Dumbbells" },
                    { 3, "Barbell" },
                    { 4, "Kettlebells" },
                    { 5, "Treadmill" },
                    { 6, "Elliptical" },
                    { 7, "Rowing Machine" },
                    { 8, "Resistance Bands" },
                    { 9, "Bench Press" },
                    { 10, "Pull-up Bar" },
                    { 11, "Medicine Ball" },
                    { 12, "Foam Roller" },
                    { 13, "Exercise Mat" },
                    { 14, "Stationary Bike" },
                    { 15, "Leg Press Machine" },
                    { 16, "Cable Machine" },
                    { 17, "Smith Machine" },
                    { 18, "Stability Ball" },
                    { 19, "Jump Rope" }
                });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beginner" },
                    { 2, "Intermediate" },
                    { 3, "Advanced" },
                    { 4, "Expert" }
                });

            migrationBuilder.InsertData(
                table: "Muscle",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Abdominals" },
                    { 2, "Abductors" },
                    { 3, "Adductors" },
                    { 4, "Biceps" },
                    { 5, "Calves" },
                    { 6, "Chest" },
                    { 7, "Forearms" },
                    { 8, "Glutes" },
                    { 9, "Hamstrings" },
                    { 10, "Lats" }
                });

            migrationBuilder.InsertData(
                table: "Muscle",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 11, "Lower Back" },
                    { 12, "Middle Back" },
                    { 13, "Neck" },
                    { 14, "Obliques" },
                    { 15, "Quadriceps" },
                    { 16, "Shoulders" },
                    { 17, "Traps" },
                    { 18, "Triceps" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoryId",
                table: "Exercises",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_EquipmentId",
                table: "Exercises",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_LevelId",
                table: "Exercises",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_MuscleId",
                table: "Exercises",
                column: "MuscleId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Muscle");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CategoryId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_EquipmentId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_LevelId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_MuscleId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MuscleId",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryMuscle",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryMuscle",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "e4627d45-a8bd-40d1-8b86-857894245855");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "a489a797-20c8-4316-9340-e995a3fbb41f");
        }
    }
}
