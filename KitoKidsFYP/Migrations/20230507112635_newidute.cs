using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitoKidsFYP.Migrations
{
    /// <inheritdoc />
    public partial class newidute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClusterFruitLevel4s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClusterFruitLevel3s",
                table: "ClusterFruitLevel3s");

            migrationBuilder.DropColumn(
                name: "QuestionAudio",
                table: "ClusterFruitLevel3s");

            migrationBuilder.RenameTable(
                name: "ClusterFruitLevel3s",
                newName: "ClusterFruitsLevel3s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClusterFruitsLevel3s",
                table: "ClusterFruitsLevel3s",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClusterFruitsLevel3s",
                table: "ClusterFruitsLevel3s");

            migrationBuilder.RenameTable(
                name: "ClusterFruitsLevel3s",
                newName: "ClusterFruitLevel3s");

            migrationBuilder.AddColumn<string>(
                name: "QuestionAudio",
                table: "ClusterFruitLevel3s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClusterFruitLevel3s",
                table: "ClusterFruitLevel3s",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClusterFruitLevel4s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterFruitLevel4s", x => x.Id);
                });
        }
    }
}
