using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    public partial class ChangedTrainerIDToUserIDInTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "TrainingTasks",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "7e8a8ee5-5a27-40be-a89c-cf6e98cf61b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "52e23a23-0921-4758-a563-ae86fe5ac4e4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TrainingTasks",
                newName: "TrainerId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "1678148a-d479-420c-8169-48ecb458d006");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "d41cb3a0-f25a-4164-b6cc-15f82cd5c3b2");
        }
    }
}
