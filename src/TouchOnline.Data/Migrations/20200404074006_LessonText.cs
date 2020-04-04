using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class LessonText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageKeyboard",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageLessons",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageSystem",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LessonTexts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTexts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonTexts");

            migrationBuilder.DropColumn(
                name: "LanguageKeyboard",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LanguageLessons",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LanguageSystem",
                table: "Users");
        }
    }
}
