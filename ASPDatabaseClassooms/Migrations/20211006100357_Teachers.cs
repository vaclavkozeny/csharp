using Microsoft.EntityFrameworkCore.Migrations;

namespace Database2.Migrations
{
    public partial class Teachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomTeacher",
                columns: table => new
                {
                    ClassroomsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomTeacher", x => new { x.ClassroomsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_ClassroomTeacher_Classrooms_ClassroomsId",
                        column: x => x.ClassroomsId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomTeacher_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[] { 1, "Josef", "Pospi" });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[] { 2, "Andrej", "Zeman" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomTeacher_TeachersId",
                table: "ClassroomTeacher",
                column: "TeachersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassroomTeacher");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
