using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntityChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Forum",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "Forum",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Forum",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Forum",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Forum",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Forum",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Forum",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                schema: "Forum",
                table: "Users",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                schema: "Forum",
                table: "Posts",
                newName: "EditDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "Forum",
                table: "Posts",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                schema: "Forum",
                table: "Answers",
                newName: "EditDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "Forum",
                table: "Answers",
                newName: "CreationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "Forum",
                table: "Users",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "EditDate",
                schema: "Forum",
                table: "Posts",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "Forum",
                table: "Posts",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "EditDate",
                schema: "Forum",
                table: "Answers",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "Forum",
                table: "Answers",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                schema: "Forum",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "Forum",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserId",
                schema: "Forum",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                schema: "Forum",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserId",
                schema: "Forum",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                schema: "Forum",
                table: "Answers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserId",
                schema: "Forum",
                table: "Answers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
