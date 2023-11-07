using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class nameoffile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FilesGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "f01dc587-f3cd-42d1-82c8-d46f875009f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f5d584a-a541-4979-9988-cc79476ea4e2", "AQAAAAEAACcQAAAAEFdX1Oqdq0W2kiKvpWWf94ItoEU2Ys0u3Oqv9VmmM3jksfbcJ/RlxpUJyuvgYdBkDA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FilesGallery");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "b2027529-96fa-4cb7-ab2a-f10a22b2c9a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a97eefd3-fdba-4a41-a47d-99c8ab1209eb", "AQAAAAEAACcQAAAAEJLnzd7JFaa2vOmvEeGCpjqElGpsO9VxgqmZH2+9swvb8m5LOkG3Sz2OrY85Qp86Mg==" });
        }
    }
}
