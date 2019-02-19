using Microsoft.EntityFrameworkCore.Migrations;

namespace App.WithAuthentication.Data.Migrations
{
    public partial class SeedApplicationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "Id", "CurrentStatus" },
                values: new object[] { 1, "New" });

            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "Id", "CurrentStatus" },
                values: new object[] { 2, "Processing" });

            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "Id", "CurrentStatus" },
                values: new object[] { 3, "Done" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
