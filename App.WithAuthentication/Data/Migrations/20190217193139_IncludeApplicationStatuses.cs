using Microsoft.EntityFrameworkCore.Migrations;

namespace App.WithAuthentication.Data.Migrations
{
    public partial class IncludeApplicationStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ApplicationStatus_ApplicationStatusId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStatus",
                table: "ApplicationStatus");

            migrationBuilder.RenameTable(
                name: "ApplicationStatus",
                newName: "ApplicationStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStatuses",
                table: "ApplicationStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ApplicationStatuses_ApplicationStatusId",
                table: "Companies",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ApplicationStatuses_ApplicationStatusId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStatuses",
                table: "ApplicationStatuses");

            migrationBuilder.RenameTable(
                name: "ApplicationStatuses",
                newName: "ApplicationStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStatus",
                table: "ApplicationStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ApplicationStatus_ApplicationStatusId",
                table: "Companies",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
