using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhenixProject.Migrations
{
    public partial class _links_and_skills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeInfoId",
                table: "Skills",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    EmployeeInfoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_EmployeeInfos_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EmployeeInfoId",
                table: "Skills",
                column: "EmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_EmployeeInfoId",
                table: "Link",
                column: "EmployeeInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_EmployeeInfos_EmployeeInfoId",
                table: "Skills",
                column: "EmployeeInfoId",
                principalTable: "EmployeeInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_EmployeeInfos_EmployeeInfoId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Skills_EmployeeInfoId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "EmployeeInfoId",
                table: "Skills");
        }
    }
}
