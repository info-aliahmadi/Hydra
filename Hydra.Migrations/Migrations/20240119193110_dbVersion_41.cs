using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPriceTax",
                schema: "Sale",
                table: "OrderItem",
                newName: "TotalPriceTax");

            migrationBuilder.RenameColumn(
                name: "PriceTax",
                schema: "Sale",
                table: "OrderItem",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "DiscountAmountTax",
                schema: "Sale",
                table: "OrderItem",
                newName: "DiscountAmount");

            migrationBuilder.RenameColumn(
                name: "OrderTotal",
                schema: "Sale",
                table: "Order",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "OrderTax",
                schema: "Sale",
                table: "Order",
                newName: "TaxAmount");

            migrationBuilder.RenameColumn(
                name: "OrderShippingTax",
                schema: "Sale",
                table: "Order",
                newName: "ShippingTax");

            migrationBuilder.RenameColumn(
                name: "OrderDiscount",
                schema: "Sale",
                table: "Order",
                newName: "ShippingAmountTax");

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                schema: "Sale",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                schema: "Sale",
                table: "Order",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                schema: "Sale",
                table: "Order",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                schema: "Sale",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingAmount",
                schema: "Sale",
                table: "Order",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_DiscountId",
                schema: "Sale",
                table: "OrderItem",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                schema: "Sale",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_PaymentId",
                schema: "Sale",
                table: "Order",
                column: "PaymentId",
                principalSchema: "Sale",
                principalTable: "Payment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Discount_DiscountId",
                schema: "Sale",
                table: "OrderItem",
                column: "DiscountId",
                principalSchema: "Sale",
                principalTable: "Discount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_PaymentId",
                schema: "Sale",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Discount_DiscountId",
                schema: "Sale",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_DiscountId",
                schema: "Sale",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentId",
                schema: "Sale",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                schema: "Sale",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                schema: "Sale",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                schema: "Sale",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                schema: "Sale",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAmount",
                schema: "Sale",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "TotalPriceTax",
                schema: "Sale",
                table: "OrderItem",
                newName: "UnitPriceTax");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "Sale",
                table: "OrderItem",
                newName: "PriceTax");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                schema: "Sale",
                table: "OrderItem",
                newName: "DiscountAmountTax");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                schema: "Sale",
                table: "Order",
                newName: "OrderTotal");

            migrationBuilder.RenameColumn(
                name: "TaxAmount",
                schema: "Sale",
                table: "Order",
                newName: "OrderTax");

            migrationBuilder.RenameColumn(
                name: "ShippingTax",
                schema: "Sale",
                table: "Order",
                newName: "OrderShippingTax");

            migrationBuilder.RenameColumn(
                name: "ShippingAmountTax",
                schema: "Sale",
                table: "Order",
                newName: "OrderDiscount");
        }
    }
}
