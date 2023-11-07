using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class seconduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "9b9df3d2-7fca-4a7e-a55d-0a5ace14a532");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d92d144b-a998-4a31-a3a6-3facd8f5754f", "AQAAAAEAACcQAAAAEBd+CDBZnq1RQmD6V4/uX5Lf3CGLMqtPj6I5ihxLRhkOtq9efD+QiP0QR2hmypt3/g==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32a2f732-6c98-4480-92e6-610b67e4cfa7", 0, "8a9fc161-934a-48c5-a6e2-f80f61db57f1", "vackoze019@g.pslib.cz", true, false, null, "VACKOZE019@G.PSLIB.CZ", "VACKOZE019@G.PSLIB.CZ", "AQAAAAEAACcQAAAAEGbkjUAVLrBwsKBuQxfgR4/aKjL/BOcXefV6U26CWfUCaGpmY7WvWh8+g3BcUujuaQ==", null, false, "", false, "vackoze019@g.pslib.cz" });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Blod", "IsDefault", "IsPublic", "Name", "OwnerId" },
                values: new object[] { 2, null, true, false, "Default", "32a2f732-6c98-4480-92e6-610b67e4cfa7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa7");

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
    }
}
