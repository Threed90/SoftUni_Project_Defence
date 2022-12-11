using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class ChangingRelationFromStoryTypeGenreToGenreStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreStoryType");

            migrationBuilder.CreateTable(
                name: "GenreStory",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    StoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreStory", x => new { x.GenresId, x.StoriesId });
                    table.ForeignKey(
                        name: "FK_GenreStory_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreStory_Stories_StoriesId",
                        column: x => x.StoriesId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreStory_StoriesId",
                table: "GenreStory",
                column: "StoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreStory");

            migrationBuilder.CreateTable(
                name: "GenreStoryType",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    StoryTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreStoryType", x => new { x.GenresId, x.StoryTypesId });
                    table.ForeignKey(
                        name: "FK_GenreStoryType_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreStoryType_StoryTypes_StoryTypesId",
                        column: x => x.StoryTypesId,
                        principalTable: "StoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreStoryType_StoryTypesId",
                table: "GenreStoryType",
                column: "StoryTypesId");
        }
    }
}
