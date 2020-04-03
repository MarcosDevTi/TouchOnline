using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class KeycodesBeginners_Keyboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeycodesBeginners",
                table: "Keyboards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeycodesBeginners",
                table: "Keyboards");
        }
    }
}
