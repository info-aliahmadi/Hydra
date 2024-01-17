using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_39 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User",
                schema: "Sale",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Sale",
                table: "Product",
                newName: "CreateUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_UserId",
                schema: "Sale",
                table: "Product",
                newName: "IX_Product_CreateUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOnUtc",
                schema: "Sale",
                table: "Product",
                type: "datetime2(6)",
                precision: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)",
                oldPrecision: 6);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                schema: "Sale",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdateUserId",
                schema: "Sale",
                table: "Product",
                column: "UpdateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CreateUser",
                schema: "Sale",
                table: "Product",
                column: "CreateUserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UpdateUser",
                schema: "Sale",
                table: "Product",
                column: "UpdateUserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_CreateUser",
                schema: "Sale",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_UpdateUser",
                schema: "Sale",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UpdateUserId",
                schema: "Sale",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                schema: "Sale",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                schema: "Sale",
                table: "Product",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CreateUserId",
                schema: "Sale",
                table: "Product",
                newName: "IX_Product_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOnUtc",
                schema: "Sale",
                table: "Product",
                type: "datetime2(6)",
                precision: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)",
                oldPrecision: 6,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User",
                schema: "Sale",
                table: "Product",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
