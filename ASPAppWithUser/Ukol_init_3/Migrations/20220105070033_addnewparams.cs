using Microsoft.EntityFrameworkCore.Migrations;

namespace Ukol_init_3.Migrations
{
    public partial class addnewparams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Threads",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThreadId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "fcc7a823-026a-4fe6-9bed-20f43d854003");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b80e04c-eef5-44dc-8721-607600cabb03", "AQAAAAEAACcQAAAAEMEopFBr9ZyDy2m/3j/E6vCC+73aHlQdyAmzR0N5mVQ81k7nhY7WqyxvqkTrJB9tqw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Threads_UserId",
                table: "Threads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ThreadId",
                table: "Comments",
                column: "ThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Threads_ThreadId",
                table: "Comments",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_UserId",
                table: "Threads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Threads_ThreadId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_UserId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Threads_UserId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ThreadId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Threads");

            migrationBuilder.AlterColumn<int>(
                name: "ThreadId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
