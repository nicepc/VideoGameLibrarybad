using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGameLibrary.Migrations
{
    public partial class updateVideoGameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "VideoGames",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "VideoGames");
        }
    }
}
