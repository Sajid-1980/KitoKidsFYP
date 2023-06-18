using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitoKidsFYP.Migrations
{
    /// <inheritdoc />
    public partial class level11Numurr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberSystemLevel1s",
                table: "NumberSystemLevel1s");

            migrationBuilder.RenameTable(
                name: "NumberSystemLevel1s",
                newName: "NumberSystemLevels");

            migrationBuilder.RenameColumn(
                name: "QuestionAudio",
                table: "NumberSystemLevels",
                newName: "QuestionAudios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberSystemLevels",
                table: "NumberSystemLevels",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberSystemLevels",
                table: "NumberSystemLevels");

            migrationBuilder.RenameTable(
                name: "NumberSystemLevels",
                newName: "NumberSystemLevel1s");

            migrationBuilder.RenameColumn(
                name: "QuestionAudios",
                table: "NumberSystemLevel1s",
                newName: "QuestionAudio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberSystemLevel1s",
                table: "NumberSystemLevel1s",
                column: "Id");
        }
    }
}
