using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class RecordedTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetRecordeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VisitedPages = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UserLocal_City = table.Column<string>(maxLength: 120, nullable: true),
                    UserLocal_ContinentCode = table.Column<string>(maxLength: 10, nullable: true),
                    UserLocal_ContinentName = table.Column<string>(maxLength: 120, nullable: true),
                    UserLocal_Latitude = table.Column<double>(nullable: true),
                    UserLocal_Longitude = table.Column<double>(nullable: true),
                    UserLocal_CountryCode = table.Column<string>(maxLength: 10, nullable: true),
                    UserLocal_CountryName = table.Column<string>(maxLength: 120, nullable: true),
                    UserLocal_PostalCode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetRecordeds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetRecordeds");
        }
    }
}
