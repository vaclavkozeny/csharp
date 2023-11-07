using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload3.Data.Migrations
{
    public partial class gallerythumbnail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "a18205ff-5678-4fa2-8bc0-e4fc5f890e61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e092e081-5116-4de9-8195-34fa92198baa", "AQAAAAEAACcQAAAAEJ/+komngSrxIEygow0s35uAVrqIKkQP6UOT3B1UFxinoBHpgiQ/pkxBhQ99B8pGnA==" });
        }
    }
}
