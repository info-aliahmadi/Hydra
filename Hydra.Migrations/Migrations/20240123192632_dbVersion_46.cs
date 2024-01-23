using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_46 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                schema: "Sale",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CurrencyId",
                schema: "Sale",
                table: "Product",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Currency",
                schema: "Sale",
                table: "Product",
                column: "CurrencyId",
                principalSchema: "Sale",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Currency",
                schema: "Sale",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CurrencyId",
                schema: "Sale",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Sale",
                table: "Product");
        }
    }
}
