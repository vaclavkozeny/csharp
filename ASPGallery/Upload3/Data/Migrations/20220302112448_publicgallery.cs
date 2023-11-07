using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class publicgallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Galleries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "b2027529-96fa-4cb7-ab2a-f10a22b2c9a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a97eefd3-fdba-4a41-a47d-99c8ab1209eb", "AQAAAAEAACcQAAAAEJLnzd7JFaa2vOmvEeGCpjqElGpsO9VxgqmZH2+9swvb8m5LOkG3Sz2OrY85Qp86Mg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Galleries");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "60c2e35c-94d0-4217-a1d7-4395371055c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b1ed7e4-906f-41ff-aae0-b14fa32bae5a", "AQAAAAEAACcQAAAAEAmKD/gF00NEx/hQIPHWz7TKrTS6XSQ0N4tdK5p+cnM+425RM25hahFcGLiU3T1YTQ==" });
        }
    }
}
