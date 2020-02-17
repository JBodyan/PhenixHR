using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhenixProject.Migrations
{
    public partial class History : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInfos_EmployeeHistories_HistoryId",
                table: "EmployeeInfos");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInfos_HistoryId",
                table: "EmployeeInfos");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "EmployeeInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeInfoId",
                table: "EmployeeHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistories_EmployeeInfoId",
                table: "EmployeeHistories",
                column: "EmployeeInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeHistories_EmployeeInfos_EmployeeInfoId",
                table: "EmployeeHistories",
                column: "EmployeeInfoId",
                principalTable: "EmployeeInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeHistories_EmployeeInfos_EmployeeInfoId",
                table: "EmployeeHistories");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeHistories_EmployeeInfoId",
                table: "EmployeeHistories");

            migrationBuilder.DropColumn(
                name: "EmployeeInfoId",
                table: "EmployeeHistories");

            migrationBuilder.AddColumn<Guid>(
                name: "HistoryId",
                table: "EmployeeInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfos_HistoryId",
                table: "EmployeeInfos",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInfos_EmployeeHistories_HistoryId",
                table: "EmployeeInfos",
                column: "HistoryId",
                principalTable: "EmployeeHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
