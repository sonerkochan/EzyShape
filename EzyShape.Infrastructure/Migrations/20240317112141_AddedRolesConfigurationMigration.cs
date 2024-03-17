using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzyShape.Infrastructure.Migrations
{
    public partial class AddedRolesConfigurationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07358494-247c-421c-8f7f-82c12be55276", "04dfb8ce-5a14-49e1-8933-664643a2bd30", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9de7285-b674-454c-9889-5210abb8d347", "04e0ea3e-9349-4635-baf8-9d48d23dfb34", "Trainer", "TRAINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347");
        }
    }
}
