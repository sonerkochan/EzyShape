using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SplitsFixedToHaveWorkoutSplitInsteadOfWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Splits_SplitId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_SplitId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "SplitId",
                table: "Workouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SplitId",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_SplitId",
                table: "Workouts",
                column: "SplitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Splits_SplitId",
                table: "Workouts",
                column: "SplitId",
                principalTable: "Splits",
                principalColumn: "Id");
        }
    }
}
