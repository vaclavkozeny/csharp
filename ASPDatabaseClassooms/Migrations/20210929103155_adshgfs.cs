using Microsoft.EntityFrameworkCore.Migrations;

namespace Database2.Migrations
{
    public partial class adshgfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassroomId", "Firstname", "Lastname", "ShoeSize" },
                values: new object[] { 2, 1003, "P4", "djadh", 55 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
