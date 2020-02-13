using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class StatusKeyboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Keyboards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Keyboards");
        }
    }
}
