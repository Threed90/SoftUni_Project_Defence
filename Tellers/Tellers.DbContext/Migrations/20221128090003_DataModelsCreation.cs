using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class DataModelsCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bio_Country_HomeCountryId",
                table: "Bio");

            migrationBuilder.DropForeignKey(
                name: "FK_Bio_Country_ResidenceCountryId",
                table: "Bio");

            migrationBuilder.DropForeignKey(
                name: "FK_Bio_Town_HomeTownId",
                table: "Bio");

            migrationBuilder.DropForeignKey(
                name: "FK_Bio_Town_ResidenceCityId",
                table: "Bio");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_Bio_BioId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_Country_CountryId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_Town_TownId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_StoryType_StoryTypeId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Bio_AdditionalInfoId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory_Profile_AuthorsId",
                table: "ProfileStory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory_Story_MyCollectiveStoriesId",
                table: "ProfileStory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory1_Profile_ReadersId",
                table: "ProfileStory1");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileStory1_Story_MyReadsId",
                table: "ProfileStory1");

            migrationBuilder.DropForeignKey(
                name: "FK_Revue_Story_StoryId",
                table: "Revue");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_Profile_CreatorId",
                table: "Story");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_StoryType_StoryTypeId",
                table: "Story");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperience_Bio_BioId",
                table: "WorkingExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperience_Country_CountryId",
                table: "WorkingExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperience_Town_TownId",
                table: "WorkingExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingExperience",
                table: "WorkingExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Town",
                table: "Town");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoryType",
                table: "StoryType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Story",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revue",
                table: "Revue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bio",
                table: "Bio");

            migrationBuilder.RenameTable(
                name: "WorkingExperience",
                newName: "WorkingExperiences");

            migrationBuilder.RenameTable(
                name: "Town",
                newName: "Towns");

            migrationBuilder.RenameTable(
                name: "StoryType",
                newName: "StoryTypes");

            migrationBuilder.RenameTable(
                name: "Story",
                newName: "Stories");

            migrationBuilder.RenameTable(
                name: "Revue",
                newName: "Revues");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Bio",
                newName: "Bios");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingExperience_TownId",
                table: "WorkingExperiences",
                newName: "IX_WorkingExperiences_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingExperience_CountryId",
                table: "WorkingExperiences",
                newName: "IX_WorkingExperiences_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingExperience_BioId",
                table: "WorkingExperiences",
                newName: "IX_WorkingExperiences_BioId");

            migrationBuilder.RenameIndex(
                name: "IX_Story_StoryTypeId",
                table: "Stories",
                newName: "IX_Stories_StoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Story_CreatorId",
                table: "Stories",
                newName: "IX_Stories_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Revue_StoryId",
                table: "Revues",
                newName: "IX_Revues_StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_UserId",
                table: "Profiles",
                newName: "IX_Profiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_AdditionalInfoId",
                table: "Profiles",
                newName: "IX_Profiles_AdditionalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_StoryTypeId",
                table: "Genres",
                newName: "IX_Genres_StoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Education_TownId",
                table: "Educations",
                newName: "IX_Educations_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_Education_CountryId",
                table: "Educations",
                newName: "IX_Educations_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Education_BioId",
                table: "Educations",
                newName: "IX_Educations_BioId");

            migrationBuilder.RenameIndex(
                name: "IX_Bio_ResidenceCountryId",
                table: "Bios",
                newName: "IX_Bios_ResidenceCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Bio_ResidenceCityId",
                table: "Bios",
                newName: "IX_Bios_ResidenceCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bio_HomeTownId",
                table: "Bios",
                newName: "IX_Bios_HomeTownId");

            migrationBuilder.RenameIndex(
                name: "IX_Bio_HomeCountryId",
                table: "Bios",
                newName: "IX_Bios_HomeCountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingExperiences",
                table: "WorkingExperiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Towns",
                table: "Towns",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoryTypes",
                table: "StoryTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revues",
                table: "Revues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bios",
                table: "Bios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bios_Countries_HomeCountryId",
                table: "Bios",
                column: "HomeCountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bios_Countries_ResidenceCountryId",
                table: "Bios",
                column: "ResidenceCountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bios_Towns_HomeTownId",
                table: "Bios",
                column: "HomeTownId",
                principalTable: "Towns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bios_Towns_ResidenceCityId",
                table: "Bios",
                column: "ResidenceCityId",
                principalTable: "Towns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Bios_BioId",
                table: "Educations",
                column: "BioId",
                principalTable: "Bios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Countries_CountryId",
                table: "Educations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Towns_TownId",
                table: "Educations",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_StoryTypes_StoryTypeId",
                table: "Genres",
                column: "StoryTypeId",
                principalTable: "StoryTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Bios_AdditionalInfoId",
                table: "Profiles",
                column: "AdditionalInfoId",
                principalTable: "Bios",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Revues_Stories_StoryId",
                table: "Revues",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Profiles_CreatorId",
                table: "Stories",
                column: "CreatorId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_StoryTypes_StoryTypeId",
                table: "Stories",
                column: "StoryTypeId",
                principalTable: "StoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperiences_Bios_BioId",
                table: "WorkingExperiences",
                column: "BioId",
                principalTable: "Bios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperiences_Countries_CountryId",
                table: "WorkingExperiences",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperiences_Towns_TownId",
                table: "WorkingExperiences",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bios_Countries_HomeCountryId",
                table: "Bios");

            migrationBuilder.DropForeignKey(
                name: "FK_Bios_Countries_ResidenceCountryId",
                table: "Bios");

            migrationBuilder.DropForeignKey(
                name: "FK_Bios_Towns_HomeTownId",
                table: "Bios");

            migrationBuilder.DropForeignKey(
                name: "FK_Bios_Towns_ResidenceCityId",
                table: "Bios");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Bios_BioId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Countries_CountryId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Towns_TownId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_StoryTypes_StoryTypeId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Bios_AdditionalInfoId",
                table: "Profiles");

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

            migrationBuilder.DropForeignKey(
                name: "FK_Revues_Stories_StoryId",
                table: "Revues");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Profiles_CreatorId",
                table: "Stories");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_StoryTypes_StoryTypeId",
                table: "Stories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperiences_Bios_BioId",
                table: "WorkingExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperiences_Countries_CountryId",
                table: "WorkingExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperiences_Towns_TownId",
                table: "WorkingExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingExperiences",
                table: "WorkingExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Towns",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoryTypes",
                table: "StoryTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revues",
                table: "Revues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bios",
                table: "Bios");

            migrationBuilder.RenameTable(
                name: "WorkingExperiences",
                newName: "WorkingExperience");

            migrationBuilder.RenameTable(
                name: "Towns",
                newName: "Town");

            migrationBuilder.RenameTable(
                name: "StoryTypes",
                newName: "StoryType");

            migrationBuilder.RenameTable(
                name: "Stories",
                newName: "Story");

            migrationBuilder.RenameTable(
                name: "Revues",
                newName: "Revue");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Bios",
                newName: "Bio");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingExperiences_TownId",
                table: "WorkingExperience",
                newName: "IX_WorkingExperience_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingExperiences_CountryId",
                table: "WorkingExperience",
                newName: "IX_WorkingExperience_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingExperiences_BioId",
                table: "WorkingExperience",
                newName: "IX_WorkingExperience_BioId");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_StoryTypeId",
                table: "Story",
                newName: "IX_Story_StoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_CreatorId",
                table: "Story",
                newName: "IX_Story_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Revues_StoryId",
                table: "Revue",
                newName: "IX_Revue_StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserId",
                table: "Profile",
                newName: "IX_Profile_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_AdditionalInfoId",
                table: "Profile",
                newName: "IX_Profile_AdditionalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_StoryTypeId",
                table: "Genre",
                newName: "IX_Genre_StoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_TownId",
                table: "Education",
                newName: "IX_Education_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_CountryId",
                table: "Education",
                newName: "IX_Education_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_BioId",
                table: "Education",
                newName: "IX_Education_BioId");

            migrationBuilder.RenameIndex(
                name: "IX_Bios_ResidenceCountryId",
                table: "Bio",
                newName: "IX_Bio_ResidenceCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Bios_ResidenceCityId",
                table: "Bio",
                newName: "IX_Bio_ResidenceCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bios_HomeTownId",
                table: "Bio",
                newName: "IX_Bio_HomeTownId");

            migrationBuilder.RenameIndex(
                name: "IX_Bios_HomeCountryId",
                table: "Bio",
                newName: "IX_Bio_HomeCountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingExperience",
                table: "WorkingExperience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Town",
                table: "Town",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoryType",
                table: "StoryType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Story",
                table: "Story",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revue",
                table: "Revue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bio",
                table: "Bio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bio_Country_HomeCountryId",
                table: "Bio",
                column: "HomeCountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bio_Country_ResidenceCountryId",
                table: "Bio",
                column: "ResidenceCountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bio_Town_HomeTownId",
                table: "Bio",
                column: "HomeTownId",
                principalTable: "Town",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bio_Town_ResidenceCityId",
                table: "Bio",
                column: "ResidenceCityId",
                principalTable: "Town",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Bio_BioId",
                table: "Education",
                column: "BioId",
                principalTable: "Bio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Country_CountryId",
                table: "Education",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Town_TownId",
                table: "Education",
                column: "TownId",
                principalTable: "Town",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_StoryType_StoryTypeId",
                table: "Genre",
                column: "StoryTypeId",
                principalTable: "StoryType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Bio_AdditionalInfoId",
                table: "Profile",
                column: "AdditionalInfoId",
                principalTable: "Bio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory_Profile_AuthorsId",
                table: "ProfileStory",
                column: "AuthorsId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory_Story_MyCollectiveStoriesId",
                table: "ProfileStory",
                column: "MyCollectiveStoriesId",
                principalTable: "Story",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory1_Profile_ReadersId",
                table: "ProfileStory1",
                column: "ReadersId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileStory1_Story_MyReadsId",
                table: "ProfileStory1",
                column: "MyReadsId",
                principalTable: "Story",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revue_Story_StoryId",
                table: "Revue",
                column: "StoryId",
                principalTable: "Story",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Profile_CreatorId",
                table: "Story",
                column: "CreatorId",
                principalTable: "Profile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Story_StoryType_StoryTypeId",
                table: "Story",
                column: "StoryTypeId",
                principalTable: "StoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperience_Bio_BioId",
                table: "WorkingExperience",
                column: "BioId",
                principalTable: "Bio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperience_Country_CountryId",
                table: "WorkingExperience",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperience_Town_TownId",
                table: "WorkingExperience",
                column: "TownId",
                principalTable: "Town",
                principalColumn: "Id");
        }
    }
}
