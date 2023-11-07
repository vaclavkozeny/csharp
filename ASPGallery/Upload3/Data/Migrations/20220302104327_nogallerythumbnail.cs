using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class nogallerythumbnail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Thumbnails_ThumbnailFileId_ThumbnailType",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_ThumbnailFileId_ThumbnailType",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "ThumbnailFileId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "ThumbnailType",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ThumbnailFileId",
                table: "Galleries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailType",
                table: "Galleries",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                column: "ConcurrencyStamp",
                value: "31179486-9b3a-4989-8430-9911fb5c35f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a21ff2b6-6ee8-4865-87db-73e06598bbfb", "AQAAAAEAACcQAAAAEJmJerwSEgciIFebNpcO81Cx8GeetdUYt7rs+Z2k/9gK1F7sGJkr5X5c5c5l4UuFGg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_ThumbnailFileId_ThumbnailType",
                table: "Galleries",
                columns: new[] { "ThumbnailFileId", "ThumbnailType" });

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Thumbnails_ThumbnailFileId_ThumbnailType",
                table: "Galleries",
                columns: new[] { "ThumbnailFileId", "ThumbnailType" },
                principalTable: "Thumbnails",
                principalColumns: new[] { "FileId", "Type" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
