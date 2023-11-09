using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_School.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_students_ClassroomId",
                table: "students",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_classrooms_ClassroomId",
                table: "students",
                column: "ClassroomId",
                principalTable: "classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_classrooms_ClassroomId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_ClassroomId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "students");
        }
    }
}
