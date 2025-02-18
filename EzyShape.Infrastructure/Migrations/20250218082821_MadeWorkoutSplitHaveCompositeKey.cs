using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MadeWorkoutSplitHaveCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutSplit",
                table: "WorkoutSplit");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSplit_SplitId",
                table: "WorkoutSplit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutSplit",
                table: "WorkoutSplit",
                columns: new[] { "SplitId", "WorkoutId" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSplit_WorkoutId",
                table: "WorkoutSplit",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutSplit",
                table: "WorkoutSplit");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSplit_WorkoutId",
                table: "WorkoutSplit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutSplit",
                table: "WorkoutSplit",
                columns: new[] { "WorkoutId", "SplitId" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSplit_SplitId",
                table: "WorkoutSplit",
                column: "SplitId");
        }
    }
}
