using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SampleDataInsert : Migration
    {
		protected void InsertUser(MigrationBuilder migrationBuilder, string username, string email, string password)
		{
			migrationBuilder.InsertData("Users", schema: "Forum", columns: new[]
				{"Username", "Email", "Password", "CreationDate"},
				values: new object[] { username, email, password, DateTime.UtcNow });
		}

		protected void InsertPost(MigrationBuilder migrationBuilder, string title, string content, long authorId)
		{
			migrationBuilder.InsertData("Posts", schema: "Forum", columns: new[]
				{"Title", "Content", "AuthorId", "CreationDate", "EditDate"},
				values: new object[] { title, content, authorId, DateTime.UtcNow, DateTime.UtcNow });
		}

		protected void InsertAnswer(MigrationBuilder migrationBuilder, string content, long postId, long authorId)
		{
			migrationBuilder.InsertData("Answers", schema: "Forum", columns: new[]
				{"Content", "PostId", "AuthorId", "CreationDate", "EditDate"},
				values: new object[] { content, postId, authorId, DateTime.UtcNow, DateTime.UtcNow });
		}

		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			InsertUser(migrationBuilder, "user1", "user1@email.com", "password1");
			InsertUser(migrationBuilder, "user2", "user2@email.com", "password2");

			InsertPost(migrationBuilder, "Title1", "Contentaaaaaaaa", 1);
			InsertPost(migrationBuilder, "Title2", "Contentbbbbbbbb", 2);

			InsertAnswer(migrationBuilder, "Answer to post1", 1, 2);
			InsertAnswer(migrationBuilder, "Answer to post2", 2, 1);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
