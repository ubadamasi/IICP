using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.WithAuthentication.Data.Migrations
{
    public partial class AddRemoveStatusAddLogDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ApplicationStatuses_ApplicationStatusId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ApplicationStatusId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusId",
                table: "Companies");

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDate",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogDate",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatusId",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ApplicationStatusId",
                table: "Companies",
                column: "ApplicationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ApplicationStatuses_ApplicationStatusId",
                table: "Companies",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
