using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_authorId",
                schema: "Forum",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "authorId",
                schema: "Forum",
                table: "Answers",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_authorId",
                schema: "Forum",
                table: "Answers",
                newName: "IX_Answers_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_AuthorId",
                schema: "Forum",
                table: "Answers",
                column: "AuthorId",
                principalSchema: "Forum",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_AuthorId",
                schema: "Forum",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                schema: "Forum",
                table: "Answers",
                newName: "authorId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_AuthorId",
                schema: "Forum",
                table: "Answers",
                newName: "IX_Answers_authorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_authorId",
                schema: "Forum",
                table: "Answers",
                column: "authorId",
                principalSchema: "Forum",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
