using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Crm");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Cms",
                table: "Slideshow",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmailInbox",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsPin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FromUserId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_User_FromUserId",
                        column: x => x.FromUserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailInboxAttachment",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailInboxId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInboxAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailInboxAttachment_EmailInbox_EmailInboxId",
                        column: x => x.EmailInboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailInbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailInboxFromAddress",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailInboxId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInboxFromAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailInboxFromAddress_EmailInbox_EmailInboxId",
                        column: x => x.EmailInboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailInbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailInboxToAddress",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailInboxId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInboxToAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailInboxToAddress_EmailInbox_EmailInboxId",
                        column: x => x.EmailInboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailInbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailOutbox",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplayToId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOutbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailOutbox_EmailInbox_ReplayToId",
                        column: x => x.ReplayToId,
                        principalSchema: "Crm",
                        principalTable: "EmailInbox",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessageAttachment",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageAttachment_Message_MessageId",
                        column: x => x.MessageId,
                        principalSchema: "Crm",
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageUser",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    ToUserId = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageUser_Message_MessageId",
                        column: x => x.MessageId,
                        principalSchema: "Crm",
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageUser_User_ToUserId",
                        column: x => x.ToUserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailOutboxAttachment",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOutboxId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOutboxAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailOutboxAttachment_EmailOutbox_EmailOutboxId",
                        column: x => x.EmailOutboxId,
                        principalTable: "EmailOutbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailOutboxFromAddress",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOutboxId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOutboxFromAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailOutboxFromAddress_EmailOutbox_EmailOutboxId",
                        column: x => x.EmailOutboxId,
                        principalTable: "EmailOutbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailOutboxToAddress",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOutboxId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOutboxToAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailOutboxToAddress_EmailOutbox_EmailOutboxId",
                        column: x => x.EmailOutboxId,
                        principalTable: "EmailOutbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailInboxAttachment_EmailInboxId",
                schema: "Crm",
                table: "EmailInboxAttachment",
                column: "EmailInboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailInboxFromAddress_EmailInboxId",
                schema: "Crm",
                table: "EmailInboxFromAddress",
                column: "EmailInboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailInboxToAddress_EmailInboxId",
                schema: "Crm",
                table: "EmailInboxToAddress",
                column: "EmailInboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOutbox_ReplayToId",
                table: "EmailOutbox",
                column: "ReplayToId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOutboxAttachment_EmailOutboxId",
                schema: "Crm",
                table: "EmailOutboxAttachment",
                column: "EmailOutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOutboxFromAddress_EmailOutboxId",
                schema: "Crm",
                table: "EmailOutboxFromAddress",
                column: "EmailOutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOutboxToAddress_EmailOutboxId",
                schema: "Crm",
                table: "EmailOutboxToAddress",
                column: "EmailOutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FromUserId",
                schema: "Crm",
                table: "Message",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageAttachment_MessageId",
                schema: "Crm",
                table: "MessageAttachment",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUser_MessageId",
                schema: "Crm",
                table: "MessageUser",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUser_ToUserId",
                schema: "Crm",
                table: "MessageUser",
                column: "ToUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailInboxAttachment",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailInboxFromAddress",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailInboxToAddress",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailOutboxAttachment",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailOutboxFromAddress",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailOutboxToAddress",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "MessageAttachment",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "MessageUser",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailOutbox");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailInbox",
                schema: "Crm");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Cms",
                table: "Slideshow",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
