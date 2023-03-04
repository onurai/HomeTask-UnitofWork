using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTaskTo03._04.Migrations
{
    public partial class FluentApiAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "tblPost");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "tblBlog");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_BlogId",
                table: "tblPost",
                newName: "IX_tblPost_BlogId");

            migrationBuilder.RenameColumn(
                name: "BlogName",
                table: "tblBlog",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "tblPost",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tblPost",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "tblPost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 13, 36, 24, 999, DateTimeKind.Local).AddTicks(1247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tblBlog",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tblBlog",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPost",
                table: "tblPost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblBlog",
                table: "tblBlog",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPost_Title",
                table: "tblPost",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblBlog_Name",
                table: "tblBlog",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPost_tblBlog_BlogId",
                table: "tblPost",
                column: "BlogId",
                principalTable: "tblBlog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblPost_tblBlog_BlogId",
                table: "tblPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPost",
                table: "tblPost");

            migrationBuilder.DropIndex(
                name: "IX_tblPost_Title",
                table: "tblPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblBlog",
                table: "tblBlog");

            migrationBuilder.DropIndex(
                name: "IX_tblBlog_Name",
                table: "tblBlog");

            migrationBuilder.RenameTable(
                name: "tblPost",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "tblBlog",
                newName: "Blogs");

            migrationBuilder.RenameIndex(
                name: "IX_tblPost_BlogId",
                table: "Posts",
                newName: "IX_Posts_BlogId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Blogs",
                newName: "BlogName");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 4, 13, 36, 24, 999, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "BlogName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
