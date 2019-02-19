using Microsoft.EntityFrameworkCore.Migrations;
using System.Data;


namespace App.WithAuthentication.Data.Migrations
{
    public partial class PopulateApplicationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationType",
                columns: new[] { "Id", "RegistrationFee", "DurationInMonths" },
                values: new object[] { 1, 0, 24 });

            migrationBuilder.InsertData(
                table: "ApplicationType",
                columns: new[] { "Id", "RegistrationFee", "DurationInMonths" },
                values: new object[] { 2, 25, 24 });

            migrationBuilder.InsertData(
                table: "ApplicationType",
                columns: new[] { "Id", "RegistrationFee", "DurationInMonths" },
                values: new object[] { 3, 50, 24 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
