using Microsoft.EntityFrameworkCore.Migrations;

namespace FitBody.DataBase.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "post_comments",
                columns: table => new
                {
                    post_id = table.Column<int>(nullable: false),
                    comment_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_comments", x => new { x.post_id, x.comment_id });
                    table.ForeignKey(
                        name: "FK_post_comments_comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_comments_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "thread_comments",
                columns: table => new
                {
                    thread_id = table.Column<int>(nullable: false),
                    comment_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thread_comments", x => new { x.thread_id, x.comment_id });
                    table.ForeignKey(
                        name: "FK_thread_comments_comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_thread_comments_threads_thread_id",
                        column: x => x.thread_id,
                        principalTable: "threads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_post_comments_comment_id",
                table: "post_comments",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_thread_comments_comment_id",
                table: "thread_comments",
                column: "comment_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post_comments");

            migrationBuilder.DropTable(
                name: "thread_comments");
        }
    }
}
