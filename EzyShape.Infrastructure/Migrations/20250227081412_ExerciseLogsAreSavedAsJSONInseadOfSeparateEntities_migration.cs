using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseLogsAreSavedAsJSONInseadOfSeparateEntities_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_Splits_SplitId",
                table: "WorkoutSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_Workouts_WorkoutId",
                table: "WorkoutSessions");

            migrationBuilder.DropTable(
                name: "WorkoutLogs");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_SplitId",
                table: "WorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_WorkoutId",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "SplitId",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "WorkoutSessions");

            migrationBuilder.AddColumn<string>(
                name: "Logs",
                table: "WorkoutSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logs",
                table: "WorkoutSessions");

            migrationBuilder.AddColumn<int>(
                name: "SplitId",
                table: "WorkoutSessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "WorkoutSessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkoutLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    WorkoutSessionId = table.Column<int>(type: "int", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutLogs_WorkoutExercises_WorkoutId_ExerciseId",
                        columns: x => new { x.WorkoutId, x.ExerciseId },
                        principalTable: "WorkoutExercises",
                        principalColumns: new[] { "WorkoutId", "ExerciseId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutLogs_WorkoutSessions_WorkoutSessionId",
                        column: x => x.WorkoutSessionId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_SplitId",
                table: "WorkoutSessions",
                column: "SplitId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_WorkoutId",
                table: "WorkoutSessions",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogs_WorkoutId_ExerciseId",
                table: "WorkoutLogs",
                columns: new[] { "WorkoutId", "ExerciseId" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogs_WorkoutSessionId",
                table: "WorkoutLogs",
                column: "WorkoutSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_Splits_SplitId",
                table: "WorkoutSessions",
                column: "SplitId",
                principalTable: "Splits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_Workouts_WorkoutId",
                table: "WorkoutSessions",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }
    }
}
