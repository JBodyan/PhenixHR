using Microsoft.EntityFrameworkCore.Migrations;

namespace PhenixProject.Migrations
{
    public partial class Added_Currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "CandidateInfos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "CandidateInfos");
        }
    }
}
