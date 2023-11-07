using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Galleries_GalleryId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_GalleryId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilesGallery",
                columns: table => new
                {
                    StoredFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesGallery", x => new { x.StoredFileId, x.GalleryId });
                    table.ForeignKey(
                        name: "FK_FilesGallery_Files_StoredFileId",
                        column: x => x.StoredFileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilesGallery_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "b06bcab0-03c9-4c9d-8409-ee2f8fe391bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "848a5cd7-9476-4f34-9de0-edd53320f29a", "AQAAAAEAACcQAAAAEKdXr1AoDTwf8Ktjfy2yicykpcx0rXY2GLIqgf6F499UWpeTKMhfUF3bOcdF29qJjw==" });

            migrationBuilder.CreateIndex(
                name: "IX_FilesGallery_GalleryId",
                table: "FilesGallery",
                column: "GalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesGallery");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Galleries");

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "fe306ccc-28b4-4a41-ab30-85012d3f3919");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "df97e79b-d40f-42eb-a6cd-51f2d7ca9f29", "AQAAAAEAACcQAAAAEEWc/2pATvi2PzqaW9wphu/NPWCpr8vHidsotUpTanGpmhQoY4NnlIuDMwiDheckyQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_GalleryId",
                table: "Files",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Galleries_GalleryId",
                table: "Files",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
