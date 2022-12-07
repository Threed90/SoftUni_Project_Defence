using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class CreateManyToManyFriendsSelfReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    MySideFriendsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OtherSideFriendsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.MySideFriendsId, x.OtherSideFriendsId });
                    table.ForeignKey(
                        name: "FK_Friends_MySideFriendsId",
                        column: x => x.MySideFriendsId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_OtherSideFriendsId",
                        column: x => x.OtherSideFriendsId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfile_OtherSideFriendsId",
                table: "Friends",
                column: "OtherSideFriendsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileProfile");
        }
    }
}
