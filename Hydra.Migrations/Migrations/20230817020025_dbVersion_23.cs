using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slideshow",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PreviewImageId = table.Column<int>(type: "int", nullable: true),
                    PreviewImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slideshow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slideshow_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slideshow_UserId",
                schema: "Cms",
                table: "Slideshow",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slideshow",
                schema: "Cms");
        }
    }
}
