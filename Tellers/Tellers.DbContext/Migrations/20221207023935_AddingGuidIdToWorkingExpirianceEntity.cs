using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class AddingGuidIdToWorkingExpirianceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "WorkingExperiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BioId",
                table: "WorkingExperiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingExperiences",
                table: "WorkingExperiences",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperiences_BioId",
                table: "WorkingExperiences",
                column: "BioId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperiences_Bios_BioId",
                table: "WorkingExperiences",
                column: "BioId",
                principalTable: "Bios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperiences_Bios_BioId",
                table: "WorkingExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingExperiences",
                table: "WorkingExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkingExperiences_BioId",
                table: "WorkingExperiences");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorkingExperiences");

            migrationBuilder.DropColumn(
                name: "BioId",
                table: "WorkingExperiences");
        }
    }
}
