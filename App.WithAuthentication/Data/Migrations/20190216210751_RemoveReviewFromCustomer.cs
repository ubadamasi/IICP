using Microsoft.EntityFrameworkCore.Migrations;

namespace App.WithAuthentication.Data.Migrations
{
    public partial class RemoveReviewFromCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewStatus",
                table: "Companies");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Companies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "ReviewStatus",
                table: "Companies",
                nullable: false,
                defaultValue: 0);
        }
    }
}
