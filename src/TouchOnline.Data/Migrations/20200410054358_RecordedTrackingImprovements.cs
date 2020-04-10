using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class RecordedTrackingImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Results",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "GetRecordeds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "GetRecordeds",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "GetRecordeds",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KeyboradId",
                table: "GetRecordeds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageBrowser",
                table: "GetRecordeds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageKeyboard",
                table: "GetRecordeds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageSystem",
                table: "GetRecordeds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "GetRecordeds",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "City",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "KeyboradId",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "LanguageBrowser",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "LanguageKeyboard",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "LanguageSystem",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "GetRecordeds");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Results",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
