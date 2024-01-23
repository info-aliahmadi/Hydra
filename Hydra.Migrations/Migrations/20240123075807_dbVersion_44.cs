using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductTag",
                schema: "Sale");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPicture_FileUpload_PictureId",
                schema: "Sale",
                table: "ProductPicture",
                column: "PictureId",
                principalSchema: "FS",
                principalTable: "FileUpload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPicture_FileUpload_PictureId",
                schema: "Sale",
                table: "ProductPicture");

            migrationBuilder.CreateTable(
                name: "ProductProductTag",
                schema: "Sale",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_ProductTag_Mapping", x => new { x.ProductId, x.ProductTagId });
                    table.ForeignKey(
                        name: "FK_ProductProductTag_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProductTag_ProductTag",
                        column: x => x.ProductTagId,
                        principalSchema: "Sale",
                        principalTable: "ProductTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTag_Mapping_Product_Id",
                schema: "Sale",
                table: "ProductProductTag",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTag_Mapping_ProductTag_Id",
                schema: "Sale",
                table: "ProductProductTag",
                column: "ProductTagId");
        }
    }
}
