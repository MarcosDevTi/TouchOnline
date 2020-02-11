using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class recordiTrackingChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLocal_City",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "UserLocal_ContinentCode",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "UserLocal_ContinentName",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "UserLocal_CountryCode",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "UserLocal_CountryName",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "UserLocal_Latitude",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "UserLocal_Longitude",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "UserLocal_PostalCode",
                table: "GetRecordeds");

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "GetRecordeds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ip",
                table: "GetRecordeds");

            migrationBuilder.AddColumn<string>(
                name: "UserLocal_City",
                table: "GetRecordeds",
                type: "character varying(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLocal_ContinentCode",
                table: "GetRecordeds",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLocal_ContinentName",
                table: "GetRecordeds",
                type: "character varying(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLocal_CountryCode",
                table: "GetRecordeds",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLocal_CountryName",
                table: "GetRecordeds",
                type: "character varying(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UserLocal_Latitude",
                table: "GetRecordeds",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UserLocal_Longitude",
                table: "GetRecordeds",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLocal_PostalCode",
                table: "GetRecordeds",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
