using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedWorkoutSessionEntity_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "WorkoutSessions");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "WorkoutSessions",
                newName: "Date");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "WorkoutSessions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "WorkoutSessions");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "WorkoutSessions",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "WorkoutSessions",
                type: "datetime2",
                nullable: true);
        }
    }
}
