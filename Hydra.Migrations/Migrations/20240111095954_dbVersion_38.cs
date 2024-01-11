using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                schema: "Auth",
                table: "Permission",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Permission",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "AUTH.CHANGE_PASSWORD", "AUTH.CHANGE_PASSWORD" },
                    { 2, "AUTH.GET_USER_LIST", "AUTH.GET_USER_LIST" },
                    { 3, "AUTH.GET_USER_BY_ID", "AUTH.GET_USER_BY_ID" },
                    { 4, "AUTH.ADD_USER", "AUTH.ADD_USER" },
                    { 5, "AUTH.UPDATE_USER", "AUTH.UPDATE_USER" },
                    { 6, "AUTH.DELETE_USER", "AUTH.DELETE_USER" },
                    { 7, "AUTH.ASSIGN_PERMISSION_TO_ROLE_BY_ROLE_ID", "AUTH.ASSIGN_PERMISSION_TO_ROLE_BY_ROLE_ID" },
                    { 8, "AUTH.GET_ROLE_LIST", "AUTH.GET_ROLE_LIST" },
                    { 9, "AUTH.GET_ROLE_BY_ID", "AUTH.GET_ROLE_BY_ID" },
                    { 10, "AUTH.ADD_ROLE", "AUTH.ADD_ROLE" },
                    { 11, "AUTH.UPDATE_ROLE", "AUTH.UPDATE_ROLE" },
                    { 12, "AUTH.DELETE_ROLE", "AUTH.DELETE_ROLE" },
                    { 13, "AUTH.GET_PERMISSION_LIST", "AUTH.GET_PERMISSION_LIST" },
                    { 14, "AUTH.GET_PERMISSION_BY_ID", "AUTH.GET_PERMISSION_BY_ID" },
                    { 15, "AUTH.ADD_PERMISSION", "AUTH.ADD_PERMISSION" },
                    { 16, "AUTH.UPDATE_PERMISSION", "AUTH.UPDATE_PERMISSION" },
                    { 17, "AUTH.DELETE_PERMISSION", "AUTH.DELETE_PERMISSION" }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "SuperAdmin", "SUPERADMIN" },
                    { 2, null, "Admin", "ADMIN" },
                    { 3, null, "User", "USER" },
                    { 4, null, "Superviser", "SUPERVISER" },
                    { 5, null, "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                schema: "Auth",
                table: "Permission",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
