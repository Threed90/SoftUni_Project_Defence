using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class RemoveStoryTextAndMakeStoryUrlRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfFile",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "StoryText",
                table: "Stories");

            migrationBuilder.AddColumn<string>(
                name: "PdfFileUrl",
                table: "Stories",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfFileUrl",
                table: "Stories");

            migrationBuilder.AddColumn<string>(
                name: "PdfFile",
                table: "Stories",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoryText",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
