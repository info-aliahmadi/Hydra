using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductProductTag",
                schema: "Sale",
                columns: table => new
                {
                    ProductTagId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductTag", x => new { x.ProductId, x.ProductTagId });
                    table.ForeignKey(
                        name: "FK_ProductProductTag_ProductTag_ProductTagId",
                        column: x => x.ProductTagId,
                        principalSchema: "Sale",
                        principalTable: "ProductTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductTag_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductTag_ProductTagId",
                schema: "Sale",
                table: "ProductProductTag",
                column: "ProductTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductTag",
                schema: "Sale");
        }
    }
}
