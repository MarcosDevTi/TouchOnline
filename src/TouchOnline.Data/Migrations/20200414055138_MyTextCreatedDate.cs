using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchOnline.Data.Migrations
{
    public partial class MyTextCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MessageSupports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_GetRecordeds_KeyboradId",
                table: "GetRecordeds",
                column: "KeyboradId");

            migrationBuilder.CreateIndex(
                name: "IX_GetRecordeds_UserId",
                table: "GetRecordeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GetRecordeds_Keyboards_KeyboradId",
                table: "GetRecordeds",
                column: "KeyboradId",
                principalTable: "Keyboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GetRecordeds_Users_UserId",
                table: "GetRecordeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetRecordeds_Keyboards_KeyboradId",
                table: "GetRecordeds");

            migrationBuilder.DropForeignKey(
                name: "FK_GetRecordeds_Users_UserId",
                table: "GetRecordeds");

            migrationBuilder.DropIndex(
                name: "IX_GetRecordeds_KeyboradId",
                table: "GetRecordeds");

            migrationBuilder.DropIndex(
                name: "IX_GetRecordeds_UserId",
                table: "GetRecordeds");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MessageSupports");
        }
    }
}
