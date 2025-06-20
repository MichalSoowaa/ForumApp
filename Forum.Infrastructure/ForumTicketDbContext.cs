using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Infrastructure
{
	public class ForumTicketDbContext : DbContext
	{
		public ForumTicketDbContext(DbContextOptions<ForumTicketDbContext> options) : base(options)
		{ }

		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Answer> Answers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Answer>()
				.HasOne(a => a.Author)
				.WithMany()
				.HasForeignKey(a => a.AuthorId)
				.OnDelete(DeleteBehavior.Restrict)
				.IsRequired();
		}
	}
}

//protected void InsertUser(MigrationBuilder migrationBuilder, string username, string email, string password)
//{
//	migrationBuilder.InsertData("Posts", schema: "Forum", columns: new[]
//		{"Username", "Email", "Password", "CreatedOn", "ModifiedOn", "CreatedByUserId", "ModifiedByUserId"},
//		values: new object[] { username, email, password, "2025-06-01", "2025-06-01", 1, 1 });
//}

//protected void InsertPost(MigrationBuilder migrationBuilder, string title, string content, long authorId)
//{
//	migrationBuilder.InsertData("Posts", schema: "Forum", columns: new[]
//		{"Title", "Content", "AuthorId", "CreatedOn", "ModifiedOn", "CreatedByUserId", "ModifiedByUserId"},
//		values: new object[] { title, content, authorId, "2025-06-01", "2025-06-01", 1, 1 });
//}

//protected void InsertAnswer(MigrationBuilder migrationBuilder, string content, long postId, long authorId)
//{
//	migrationBuilder.InsertData("Posts", schema: "Forum", columns: new[]
//		{"Content", "PostId", "AuthorId", "CreatedOn", "ModifiedOn", "CreatedByUserId", "ModifiedByUserId"},
//		values: new object[] { content, postId, authorId, "2025-06-01", "2025-06-01", 1, 1 });
//}

///// <inheritdoc />
//protected override void Up(MigrationBuilder migrationBuilder)
//{
//	InsertUser(migrationBuilder, "user1", "user1@email.com", "password1");
//	InsertUser(migrationBuilder, "user2", "user2@email.com", "password2");

//	InsertPost(migrationBuilder, "Title1", "Contentaaaaaaaa", 1);
//	InsertPost(migrationBuilder, "Title2", "Contentbbbbbbbb", 2);

//	InsertAnswer(migrationBuilder, "Answer to post1", 1, 2);
//	InsertAnswer(migrationBuilder, "Answer to post2", 2, 1);
//}