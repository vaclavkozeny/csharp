using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class gallerythumb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Blod",
                table: "Galleries",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "dac1e88f-4d4f-4cd1-abba-f7fc00b6b90c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01f26808-0d2b-4757-9a80-71bc3e3bbf18", "AQAAAAEAACcQAAAAEMhKCjRxiAbzWUNiR7ju7wRw3+lp/FhJyK/rQxCz4w9mJOMahYoXZWmArwkGnlV0lg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blod",
                table: "Galleries");

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
    }
}
