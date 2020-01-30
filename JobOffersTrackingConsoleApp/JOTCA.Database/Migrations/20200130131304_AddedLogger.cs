using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JOTCA.Database.Migrations
{
    public partial class AddedLogger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoggingChanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldStatus = table.Column<string>(nullable: true),
                    ChangeToStatus = table.Column<string>(nullable: true),
                    DateOfChanging = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggingChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoggingChanges_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoggingChanges_CompanyId",
                table: "LoggingChanges",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoggingChanges");
        }
    }
}
