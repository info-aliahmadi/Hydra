using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                schema: "Sale",
                table: "Manufacturer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                schema: "Sale",
                table: "Category",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Category",
                columns: new[] { "Id", "CreatedOnUtc", "Deleted", "Description", "DisplayOrder", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "ParentCategoryId", "PictureId", "Published", "ShowOnHomepage", "UpdatedOnUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), false, "Description of Category 1", 1, "MetaDescription", "MetaKeywords", "Title", "Category 1", null, null, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), false, "Description of Category 2", 2, "MetaDescription", "MetaKeywords", "Title", "Category 2", null, null, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Discount",
                columns: new[] { "Id", "AdminComment", "CouponCode", "DiscountAmount", "DiscountLimitationId", "DiscountPercentage", "DiscountTypeId", "EndDateUtc", "IsActive", "LimitationTimes", "MaximumDiscountAmount", "MaximumDiscountedQuantity", "Name", "RequiresCouponCode", "StartDateUtc", "UsePercentage" },
                values: new object[,]
                {
                    { 1, "AdminComment", "CoponCode1", 0m, 0, 4m, 5, null, true, 1, null, null, "Discount 1", true, null, true },
                    { 2, "AdminComment", "CoponCode2", 0m, 15, 6m, 5, null, true, 1, null, null, "Discount 2", true, null, true }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Manufacturer",
                columns: new[] { "Id", "CreatedOnUtc", "Deleted", "Description", "DisplayOrder", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "PictureId", "Published", "UpdatedOnUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), false, "Description of Category 1", 1, "MetaDescription", "MetaKeywords", "Title", "Manufacturer 1", null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), false, "Description of Category 2", 2, "MetaDescription", "MetaKeywords", "Title", "Manufacturer 2", null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "ProductTag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tag 1" },
                    { 2, "Tag 2" },
                    { 3, "Tag 3" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "TaxCategory",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "5% Tax" },
                    { 2, 2, "9% Tax" },
                    { 3, 3, "20% Tax" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Discount",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Discount",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "ProductTag",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "ProductTag",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "ProductTag",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "TaxCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "TaxCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "TaxCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                schema: "Sale",
                table: "Manufacturer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                schema: "Sale",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
