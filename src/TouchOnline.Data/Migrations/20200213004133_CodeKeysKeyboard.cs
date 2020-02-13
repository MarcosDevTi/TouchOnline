using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class CodeKeysKeyboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeKeys",
                table: "Keyboards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeKeys",
                table: "Keyboards");
        }
    }
}
