using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_School.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_classrooms_ClassroomId",
                table: "students");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_students_classrooms_ClassroomId",
                table: "students",
                column: "ClassroomId",
                principalTable: "classrooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_classrooms_ClassroomId",
                table: "students");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_students_classrooms_ClassroomId",
                table: "students",
                column: "ClassroomId",
                principalTable: "classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
