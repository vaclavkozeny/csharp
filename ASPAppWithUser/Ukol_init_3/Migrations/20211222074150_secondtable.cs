using Microsoft.EntityFrameworkCore.Migrations;

namespace Ukol_init_3.Migrations
{
    public partial class secondtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "b6dcb60a-64ab-483b-8ad3-8477a58cbb60");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e01a21a4-a252-475b-a432-630c941b3531", "AQAAAAEAACcQAAAAECFGM+mvLKcnWk5q76fLBP0fDfJPXhE7bUDbS6lwkk6JRsxAkGSMiEHLM3zFg2w+vA==" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Message", "ThreadId", "UserId" },
                values: new object[] { 1, "Test", 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "0f5958d6-8759-4d1a-8fd5-d6788837162a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4b93e41-5adf-479b-b8f6-73ed49c3736f", "AQAAAAEAACcQAAAAEAR4+BhHc4vEMUdCVakgI4XW38ywC7MQqLFmvrci2gjUw8A+eTXITj/F8LcNgU5PIg==" });
        }
    }
}
