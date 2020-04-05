using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class LessonTextUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "LessonTexts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonTexts_UserId",
                table: "LessonTexts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTexts_Users_UserId",
                table: "LessonTexts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonTexts_Users_UserId",
                table: "LessonTexts");

            migrationBuilder.DropIndex(
                name: "IX_LessonTexts_UserId",
                table: "LessonTexts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LessonTexts");
        }
    }
}
