using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.WithAuthentication.Data.Migrations
{
    public partial class AddApplicationTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationTypeId",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationFee = table.Column<short>(nullable: false),
                    DurationInMonths = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ApplicationTypeId",
                table: "Companies",
                column: "ApplicationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ApplicationType_ApplicationTypeId",
                table: "Companies",
                column: "ApplicationTypeId",
                principalTable: "ApplicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ApplicationType_ApplicationTypeId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "ApplicationType");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ApplicationTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ApplicationTypeId",
                table: "Companies");
        }
    }
}
