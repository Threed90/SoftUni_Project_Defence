using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class AddingProfileReferenceToBioEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_AdditionalInfoId",
                table: "Profiles");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Bios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AdditionalInfoId",
                table: "Profiles",
                column: "AdditionalInfoId",
                unique: true,
                filter: "[AdditionalInfoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_AdditionalInfoId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Bios");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AdditionalInfoId",
                table: "Profiles",
                column: "AdditionalInfoId");
        }
    }
}
