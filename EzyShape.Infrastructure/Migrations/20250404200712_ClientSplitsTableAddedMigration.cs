using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClientSplitsTableAddedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientSplit_AspNetUsers_UserId",
                table: "ClientSplit");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientSplit_Splits_SplitId",
                table: "ClientSplit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientSplit",
                table: "ClientSplit");

            migrationBuilder.RenameTable(
                name: "ClientSplit",
                newName: "ClientSplits");

            migrationBuilder.RenameIndex(
                name: "IX_ClientSplit_SplitId",
                table: "ClientSplits",
                newName: "IX_ClientSplits_SplitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientSplits",
                table: "ClientSplits",
                columns: new[] { "UserId", "SplitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientSplits_AspNetUsers_UserId",
                table: "ClientSplits",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientSplits_Splits_SplitId",
                table: "ClientSplits",
                column: "SplitId",
                principalTable: "Splits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientSplits_AspNetUsers_UserId",
                table: "ClientSplits");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientSplits_Splits_SplitId",
                table: "ClientSplits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientSplits",
                table: "ClientSplits");

            migrationBuilder.RenameTable(
                name: "ClientSplits",
                newName: "ClientSplit");

            migrationBuilder.RenameIndex(
                name: "IX_ClientSplits_SplitId",
                table: "ClientSplit",
                newName: "IX_ClientSplit_SplitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientSplit",
                table: "ClientSplit",
                columns: new[] { "UserId", "SplitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientSplit_AspNetUsers_UserId",
                table: "ClientSplit",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientSplit_Splits_SplitId",
                table: "ClientSplit",
                column: "SplitId",
                principalTable: "Splits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
