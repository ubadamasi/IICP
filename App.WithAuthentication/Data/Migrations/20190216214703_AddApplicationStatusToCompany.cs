using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.WithAuthentication.Data.Migrations
{
    public partial class AddApplicationStatusToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatusId",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ApplicationStatusId",
                table: "Companies",
                column: "ApplicationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ApplicationStatus_ApplicationStatusId",
                table: "Companies",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ApplicationStatus_ApplicationStatusId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ApplicationStatusId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusId",
                table: "Companies");
        }
    }
}
