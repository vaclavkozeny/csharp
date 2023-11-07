using Microsoft.EntityFrameworkCore.Migrations;

namespace Ukol_init_3.Migrations
{
    public partial class noseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83b8d17b-ead8-4d25-ac97-fd5dce157942", "AQAAAAEAACcQAAAAEA1MED+S6D62Tj2pvkTrqzt1ihv2e3VyS2YN73xEcWLa5hUPdwUtH7mnPa50kGK24w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "c0c285b5-d6c7-4804-bd05-c2101070b496");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e454a18-db88-452c-94c1-d7d326027765", "AQAAAAEAACcQAAAAEEigdgygnyc/+dlMMVfAgw0YCXxqtr1dDhLhEb1MI7mkHdE0LDbUrSnDkeUgYt1jWA==" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 1, "Test", null });
        }
    }
}
