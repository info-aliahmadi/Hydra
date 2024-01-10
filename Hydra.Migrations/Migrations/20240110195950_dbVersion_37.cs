using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PreviewImageId",
                schema: "Cms",
                table: "Menu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970) });

            migrationBuilder.UpdateData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970) });

            migrationBuilder.UpdateData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970) });

            migrationBuilder.InsertData(
                schema: "Cms",
                table: "LinkSection",
                columns: new[] { "Id", "IsVisible", "Key", "Title" },
                values: new object[,]
                {
                    { 1, true, "Categories", "Categories" },
                    { 2, true, "RecentPosts", "Recent Post" }
                });

            migrationBuilder.InsertData(
                schema: "Cms",
                table: "Menu",
                columns: new[] { "Id", "Order", "ParentId", "PreviewImageId", "Title", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 0, null, null, "About", "/About", 1 },
                    { 2, 1, null, null, "Service", "/Service", 1 },
                    { 3, 2, null, null, "Pricing", "/Pricing", 1 },
                    { 4, 3, null, null, "Contact", "/Contact", 1 },
                    { 5, 4, null, null, "Blog", "/Blog", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Cms",
                table: "LinkSection",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Cms",
                table: "LinkSection",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Cms",
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Cms",
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Cms",
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Cms",
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Cms",
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "PreviewImageId",
                schema: "Cms",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8977), new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8979) });

            migrationBuilder.UpdateData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8982), new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8982) });

            migrationBuilder.UpdateData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8985), new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8985) });
        }
    }
}
