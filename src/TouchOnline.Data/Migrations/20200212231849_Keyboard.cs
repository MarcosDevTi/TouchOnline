using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class Keyboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keyboards");
        }
    }
}
