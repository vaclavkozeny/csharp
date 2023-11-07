using Microsoft.EntityFrameworkCore.Migrations;

namespace Ukol_init_3.Migrations
{
    public partial class seedname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "4e334d0b-a5a3-4b2d-928e-4dfd4d51c41d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "8ab4a48c-e005-4731-b933-854b8c97c548", "Vaclav", "Kozeny", "AQAAAAEAACcQAAAAEKqa8v0akQfPgBsagWgWwa5clNAY4zlkA3PLvlvUxCSQIaEol4TYZRKCDe5Tz6gD2Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "b447f829-d6c7-4bf3-b78a-c78405833c53");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "83b8d17b-ead8-4d25-ac97-fd5dce157942", "Test", "Test", "AQAAAAEAACcQAAAAEA1MED+S6D62Tj2pvkTrqzt1ihv2e3VyS2YN73xEcWLa5hUPdwUtH7mnPa50kGK24w==" });
        }
    }
}
