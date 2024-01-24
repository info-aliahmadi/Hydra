using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_48 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                schema: "Sale",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Length",
                schema: "Sale",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "Sale",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Width",
                schema: "Sale",
                table: "Product");

            migrationBuilder.AlterColumn<bool>(
                name: "AllowedQuantities",
                schema: "Sale",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AttributeType = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: true),
                    StockType = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ReservedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarehouseInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Attribute",
                        column: x => x.AttributeId,
                        principalSchema: "Sale",
                        principalTable: "ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductAttribute",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Attribute_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_Attribute",
                        column: x => x.AttributeId,
                        principalSchema: "Sale",
                        principalTable: "ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "ProductAttribute",
                columns: new[] { "Id", "AttributeType", "Description", "DisplayOrder", "Name", "PictureId", "Value" },
                values: new object[,]
                {
                    { 1, 0, null, 1, "Blue", null, "blue" },
                    { 2, 0, null, 2, "Blue", null, "red" },
                    { 3, 0, null, 3, "White", null, "#fff" },
                    { 4, 0, null, 4, "Black", null, "#000" },
                    { 5, 1, "Small Means S US Size", 5, "Small size", null, "#Small" },
                    { 6, 1, "Small Means M US Size", 6, "Medium", null, "#Medium" },
                    { 7, 1, "Small Means XL US Size", 7, "Large", null, "#Large" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_AttributeType",
                schema: "Sale",
                table: "ProductAttribute",
                column: "AttributeType");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_DisplayOrder",
                schema: "Sale",
                table: "ProductAttribute",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_AttributeId",
                schema: "Sale",
                table: "ProductInventory",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarehouseInventory_ProductId",
                schema: "Sale",
                table: "ProductInventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PCM_Product_and_Attribute",
                schema: "Sale",
                table: "ProductProductAttribute",
                columns: new[] { "AttributeId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Attribute_Mapping_AttributeId",
                schema: "Sale",
                table: "ProductProductAttribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Attribute_Mapping_ProductId",
                schema: "Sale",
                table: "ProductProductAttribute",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Product",
                schema: "Sale",
                table: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductInventory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductProductAttribute",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductAttribute",
                schema: "Sale");

            migrationBuilder.AlterColumn<bool>(
                name: "AllowedQuantities",
                schema: "Sale",
                table: "Product",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                schema: "Sale",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                schema: "Sale",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                schema: "Sale",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                schema: "Sale",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
