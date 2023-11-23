using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "EmailOutbox",
                newName: "EmailOutbox",
                newSchema: "Crm");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                schema: "Crm",
                table: "EmailOutbox",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "EmailOutbox",
                schema: "Crm",
                newName: "EmailOutbox");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "EmailOutbox",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }
    }
}
