using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlTitle",
                schema: "Cms",
                table: "Page",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Cms",
                table: "Page",
                newName: "PageTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                schema: "Cms",
                table: "Page",
                newName: "UrlTitle");

            migrationBuilder.RenameColumn(
                name: "PageTitle",
                schema: "Cms",
                table: "Page",
                newName: "Title");
        }
    }
}
