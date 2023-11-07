using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class testnevm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "5e958ba7-4f1c-467b-93cf-3d541986a5e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "145514a4-1fdc-494a-a267-0476e496d96b", "AQAAAAEAACcQAAAAEP3I7AwFhz1hIpkyYULkGvNNq98iE2W6ga9NpRBs1vqLGAlKCmBgV6DsF//2V3A/rg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
