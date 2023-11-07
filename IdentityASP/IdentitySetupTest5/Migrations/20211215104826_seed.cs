using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentitySetupTest5.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d50f61e2-f8fa-42c7-acc4-8d83398d375e", "5cf2212f-153d-4498-bb4b-5edf805fb9a3", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32a2f732-6c98-4480-92e6-610b67e4cfa9", 0, "2cb58935-b7ed-4a1f-860c-ab109fbed203", "vackoze019@pslib.cz", true, false, null, "Test", "VACKOZE019@PSLIB.CZ", "VACKOZE019@PSLIB.CZ", "AQAAAAEAACcQAAAAEGzpIcCQZCwjnA5IaJa7bdh9bfDVuNdjj2cwET4+fz80pleqXh16C5zND8EpC8bOcA==", null, false, "", false, "vackoze019@pslib.cz" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d50f61e2-f8fa-42c7-acc4-8d83398d375e", "32a2f732-6c98-4480-92e6-610b67e4cfa9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d50f61e2-f8fa-42c7-acc4-8d83398d375e", "32a2f732-6c98-4480-92e6-610b67e4cfa9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9");
        }
    }
}
