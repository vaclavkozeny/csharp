using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
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
                value: "a2ca065b-5b0d-4fa4-83b8-03e0181c6438");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b32193fe-716c-48ff-9522-2863ec074ad1", "AQAAAAEAACcQAAAAEPY/3PrO2mWVx98znGtF4IsPSu25At2vXiDFPzaSfFOm7gVXMqUQ/IwH6c/Agov9DQ==" });

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Default");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "b06bcab0-03c9-4c9d-8409-ee2f8fe391bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "848a5cd7-9476-4f34-9de0-edd53320f29a", "AQAAAAEAACcQAAAAEKdXr1AoDTwf8Ktjfy2yicykpcx0rXY2GLIqgf6F499UWpeTKMhfUF3bOcdF29qJjw==" });

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: null);
        }
    }
}
