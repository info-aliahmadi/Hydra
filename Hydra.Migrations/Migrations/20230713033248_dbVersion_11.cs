using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FS");

            migrationBuilder.CreateTable(
                name: "FileUpload",
                schema: "FS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileUpload",
                schema: "FS");
        }
    }
}
