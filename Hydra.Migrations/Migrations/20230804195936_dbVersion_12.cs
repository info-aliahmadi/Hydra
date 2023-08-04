using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LargeThumbnail",
                schema: "Cms",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "SmallThumbnail",
                schema: "Cms",
                table: "Article");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                schema: "Cms",
                table: "Topic",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "Cms",
                table: "Topic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Directory",
                schema: "FS",
                table: "FileUpload",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "FS",
                table: "FileUpload",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreviewImageId",
                schema: "Cms",
                table: "Article",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviewImageUrl",
                schema: "Cms",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileUpload_UserId",
                schema: "FS",
                table: "FileUpload",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUpload_User_UserId",
                schema: "FS",
                table: "FileUpload",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUpload_User_UserId",
                schema: "FS",
                table: "FileUpload");

            migrationBuilder.DropIndex(
                name: "IX_FileUpload_UserId",
                schema: "FS",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                schema: "Cms",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Cms",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Directory",
                schema: "FS",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "FS",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "PreviewImageId",
                schema: "Cms",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "PreviewImageUrl",
                schema: "Cms",
                table: "Article");

            migrationBuilder.AddColumn<string>(
                name: "LargeThumbnail",
                schema: "Cms",
                table: "Article",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SmallThumbnail",
                schema: "Cms",
                table: "Article",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
