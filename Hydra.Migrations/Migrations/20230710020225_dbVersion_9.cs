using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryContent",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Content",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "Cms");

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LargeThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_User_EditorId",
                        column: x => x.EditorId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Article_User_WriterId",
                        column: x => x.WriterId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Topic_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Cms",
                        principalTable: "Topic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleTopic",
                schema: "Cms",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTopic", x => new { x.ArticlesId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_ArticleTopic_Article_ArticlesId",
                        column: x => x.ArticlesId,
                        principalSchema: "Cms",
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTopic_Topic_TopicsId",
                        column: x => x.TopicsId,
                        principalSchema: "Cms",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_EditorId",
                schema: "Cms",
                table: "Article",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_WriterId",
                schema: "Cms",
                table: "Article",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTopic_TopicsId",
                schema: "Cms",
                table: "ArticleTopic",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ParentId",
                schema: "Cms",
                table: "Topic",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTopic",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Article",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Topic",
                schema: "Cms");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Author_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Cms",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryContent",
                schema: "Cms",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryContent", x => new { x.CategoryId, x.ContentId });
                    table.ForeignKey(
                        name: "FK_CategoryContent_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Cms",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryContent_Content_ContentId",
                        column: x => x.ContentId,
                        principalSchema: "Cms",
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_UserId",
                schema: "Cms",
                table: "Author",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryContent_ContentId",
                schema: "Cms",
                table: "CategoryContent",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_AuthorId",
                schema: "Cms",
                table: "Content",
                column: "AuthorId");
        }
    }
}
