using Microsoft.EntityFrameworkCore.Migrations;

namespace Ukol_init_3.Migrations
{
    public partial class datamodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Threads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Comments",
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
                value: "c0c285b5-d6c7-4804-bd05-c2101070b496");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e454a18-db88-452c-94c1-d7d326027765", "AQAAAAEAACcQAAAAEEigdgygnyc/+dlMMVfAgw0YCXxqtr1dDhLhEb1MI7mkHdE0LDbUrSnDkeUgYt1jWA==" });

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Threads_ThreadId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ThreadId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Threads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "98a74141-9dd8-4a8f-9115-899c87645850");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1270e83b-2e82-4353-a76b-fef57c4121cf", "AQAAAAEAACcQAAAAEM00OhlYTip7T1rKkCBCz4GIMEGpoqA8pK1o6jS3YEcZ6KnfDCgbuFdKQFMZ1FxDRQ==" });
        }
    }
}
