using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class IsDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Galleries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "a18205ff-5678-4fa2-8bc0-e4fc5f890e61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e092e081-5116-4de9-8195-34fa92198baa", "AQAAAAEAACcQAAAAEJ/+komngSrxIEygow0s35uAVrqIKkQP6UOT3B1UFxinoBHpgiQ/pkxBhQ99B8pGnA==" });

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDefault",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Galleries");

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
        }
    }
}
