using Microsoft.EntityFrameworkCore.Migrations;

namespace Database2.Migrations
{
    public partial class test22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Firstname", "Lastname" },
                values: new object[] { "Pepa", "Nocvak" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Firstname", "Lastname" },
                values: new object[] { "P4", "djadh" });
        }
    }
}
