using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class CreateRelationBetweenRevueAndProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Revues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Revues_ProfileId",
                table: "Revues",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revues_Profiles_ProfileId",
                table: "Revues",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revues_Profiles_ProfileId",
                table: "Revues");

            migrationBuilder.DropIndex(
                name: "IX_Revues_ProfileId",
                table: "Revues");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Revues");
        }
    }
}
