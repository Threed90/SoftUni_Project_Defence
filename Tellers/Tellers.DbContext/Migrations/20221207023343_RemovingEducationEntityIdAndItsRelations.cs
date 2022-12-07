using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class RemovingEducationEntityIdAndItsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Bios_BioId",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_BioId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "BioId",
                table: "Educations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "BioId",
                table: "Educations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_BioId",
                table: "Educations",
                column: "BioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Bios_BioId",
                table: "Educations",
                column: "BioId",
                principalTable: "Bios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
