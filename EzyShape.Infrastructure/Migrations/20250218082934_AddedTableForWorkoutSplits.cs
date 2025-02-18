using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableForWorkoutSplits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSplit_Splits_SplitId",
                table: "WorkoutSplit");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSplit_Workouts_WorkoutId",
                table: "WorkoutSplit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutSplit",
                table: "WorkoutSplit");

            migrationBuilder.RenameTable(
                name: "WorkoutSplit",
                newName: "WorkoutSplits");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSplit_WorkoutId",
                table: "WorkoutSplits",
                newName: "IX_WorkoutSplits_WorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutSplits",
                table: "WorkoutSplits",
                columns: new[] { "SplitId", "WorkoutId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSplits_Splits_SplitId",
                table: "WorkoutSplits",
                column: "SplitId",
                principalTable: "Splits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSplits_Workouts_WorkoutId",
                table: "WorkoutSplits",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSplits_Splits_SplitId",
                table: "WorkoutSplits");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSplits_Workouts_WorkoutId",
                table: "WorkoutSplits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutSplits",
                table: "WorkoutSplits");

            migrationBuilder.RenameTable(
                name: "WorkoutSplits",
                newName: "WorkoutSplit");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSplits_WorkoutId",
                table: "WorkoutSplit",
                newName: "IX_WorkoutSplit_WorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutSplit",
                table: "WorkoutSplit",
                columns: new[] { "SplitId", "WorkoutId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSplit_Splits_SplitId",
                table: "WorkoutSplit",
                column: "SplitId",
                principalTable: "Splits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSplit_Workouts_WorkoutId",
                table: "WorkoutSplit",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
