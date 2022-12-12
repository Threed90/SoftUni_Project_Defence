using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class RemovingPicturePathFromProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Profiles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
