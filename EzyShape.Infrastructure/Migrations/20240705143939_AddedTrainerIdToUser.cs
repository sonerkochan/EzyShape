using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    public partial class AddedTrainerIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TrainerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "AspNetUsers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_UserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "b9653425-c431-49fe-b82c-e287db3e0c83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "24a46b5f-0514-48f9-ac7e-fff43906e68b");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
