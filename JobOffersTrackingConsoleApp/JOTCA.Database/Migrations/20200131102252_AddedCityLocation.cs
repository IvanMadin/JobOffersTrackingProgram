using Microsoft.EntityFrameworkCore.Migrations;

namespace JOTCA.Database.Migrations
{
    public partial class AddedCityLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobOffers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobOffers");
        }
    }
}
