using Microsoft.EntityFrameworkCore.Migrations;

namespace PhenixProject.Migrations
{
    public partial class PathCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathCV",
                table: "CandidateInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathCV",
                table: "CandidateInfos");
        }
    }
}
