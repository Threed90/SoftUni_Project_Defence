using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tellers.DbContext.Migrations
{
    public partial class DbNormalizationAndRelationAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bios_Countries_HomeCountryId",
                table: "Bios");

            migrationBuilder.DropForeignKey(
                name: "FK_Bios_Countries_ResidenceCountryId",
                table: "Bios");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Bios_BioId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Countries_CountryId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_StoryTypes_StoryTypeId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Revues_Stories_StoryId",
                table: "Revues");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperiences_Bios_BioId",
                table: "WorkingExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperiences_Countries_CountryId",
                table: "WorkingExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkingExperiences_CountryId",
                table: "WorkingExperiences");

            migrationBuilder.DropIndex(
                name: "IX_Genres_StoryTypeId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Educations_CountryId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Bios_HomeCountryId",
                table: "Bios");

            migrationBuilder.DropIndex(
                name: "IX_Bios_ResidenceCountryId",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "WorkingExperiences");

            migrationBuilder.DropColumn(
                name: "StoryTypeId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "HomeCountryId",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "ResidenceCountryId",
                table: "Bios");

            migrationBuilder.AlterColumn<Guid>(
                name: "BioId",
                table: "WorkingExperiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Towns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "StoryId",
                table: "Revues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BioId",
                table: "Educations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
                name: "IX_Towns_CountryId",
                table: "Towns",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreStoryType_StoryTypesId",
                table: "GenreStoryType",
                column: "StoryTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Bios_BioId",
                table: "Educations",
                column: "BioId",
                principalTable: "Bios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revues_Stories_StoryId",
                table: "Revues",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Countries_CountryId",
                table: "Towns",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Educations_Bios_BioId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Revues_Stories_StoryId",
                table: "Revues");

            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Countries_CountryId",
                table: "Towns");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperiences_Bios_BioId",
                table: "WorkingExperiences");

            migrationBuilder.DropTable(
                name: "GenreStoryType");

            migrationBuilder.DropIndex(
                name: "IX_Towns_CountryId",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Towns");

            migrationBuilder.AlterColumn<Guid>(
                name: "BioId",
                table: "WorkingExperiences",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "WorkingExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StoryId",
                table: "Revues",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "StoryTypeId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BioId",
                table: "Educations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeCountryId",
                table: "Bios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidenceCountryId",
                table: "Bios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperiences_CountryId",
                table: "WorkingExperiences",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_StoryTypeId",
                table: "Genres",
                column: "StoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CountryId",
                table: "Educations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bios_HomeCountryId",
                table: "Bios",
                column: "HomeCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bios_ResidenceCountryId",
                table: "Bios",
                column: "ResidenceCountryId");

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
                name: "FK_Genres_StoryTypes_StoryTypeId",
                table: "Genres",
                column: "StoryTypeId",
                principalTable: "StoryTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Revues_Stories_StoryId",
                table: "Revues",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id");

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
        }
    }
}
