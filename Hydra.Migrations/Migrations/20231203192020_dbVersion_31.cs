using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Article_PreviewImageId",
                schema: "Cms",
                table: "Article",
                column: "PreviewImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_FileUpload_PreviewImageId",
                schema: "Cms",
                table: "Article",
                column: "PreviewImageId",
                principalSchema: "FS",
                principalTable: "FileUpload",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_FileUpload_PreviewImageId",
                schema: "Cms",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_PreviewImageId",
                schema: "Cms",
                table: "Article");
        }
    }
}
