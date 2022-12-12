using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class ChangingLoginInProfileStoryRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory_Profiles_AuthorsId",
                table: "ProfileStory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory_Stories_MyCollectiveStoriesId",
                table: "ProfileStory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory1_Profiles_ReadersId",
                table: "ProfileStory1");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory1_Stories_MyReadsId",
                table: "ProfileStory1");

            migrationBuilder.RenameColumn(
                name: "ReadersId",
                table: "ProfileStory1",
                newName: "MyStoriesId");

            migrationBuilder.RenameColumn(
                name: "MyReadsId",
                table: "ProfileStory1",
                newName: "AuthorsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileStory1_ReadersId",
                table: "ProfileStory1",
                newName: "IX_ProfileStory1_MyStoriesId");

            migrationBuilder.RenameColumn(
                name: "MyCollectiveStoriesId",
                table: "ProfileStory",
                newName: "ReadersId");

            migrationBuilder.RenameColumn(
                name: "AuthorsId",
                table: "ProfileStory",
                newName: "MyReadsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileStory_MyCollectiveStoriesId",
                table: "ProfileStory",
                newName: "IX_ProfileStory_ReadersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory_Profiles_ReadersId",
                table: "ProfileStory",
                column: "ReadersId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory_Stories_MyReadsId",
                table: "ProfileStory",
                column: "MyReadsId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory1_Profiles_AuthorsId",
                table: "ProfileStory1",
                column: "AuthorsId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory1_Stories_MyStoriesId",
                table: "ProfileStory1",
                column: "MyStoriesId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory_Profiles_ReadersId",
                table: "ProfileStory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory_Stories_MyReadsId",
                table: "ProfileStory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory1_Profiles_AuthorsId",
                table: "ProfileStory1");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory1_Stories_MyStoriesId",
                table: "ProfileStory1");

            migrationBuilder.RenameColumn(
                name: "MyStoriesId",
                table: "ProfileStory1",
                newName: "ReadersId");

            migrationBuilder.RenameColumn(
                name: "AuthorsId",
                table: "ProfileStory1",
                newName: "MyReadsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileStory1_MyStoriesId",
                table: "ProfileStory1",
                newName: "IX_ProfileStory1_ReadersId");

            migrationBuilder.RenameColumn(
                name: "ReadersId",
                table: "ProfileStory",
                newName: "MyCollectiveStoriesId");

            migrationBuilder.RenameColumn(
                name: "MyReadsId",
                table: "ProfileStory",
                newName: "AuthorsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileStory_ReadersId",
                table: "ProfileStory",
                newName: "IX_ProfileStory_MyCollectiveStoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory_Profiles_AuthorsId",
                table: "ProfileStory",
                column: "AuthorsId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory_Stories_MyCollectiveStoriesId",
                table: "ProfileStory",
                column: "MyCollectiveStoriesId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory1_Profiles_ReadersId",
                table: "ProfileStory1",
                column: "ReadersId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory1_Stories_MyReadsId",
                table: "ProfileStory1",
                column: "MyReadsId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
