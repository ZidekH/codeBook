using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDatabase.Migrations
{
    public partial class ddfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "PlayerWeekendStatistics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWeekendStatistics_PlayerId",
                table: "PlayerWeekendStatistics",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerWeekendStatistics_Players_PlayerId",
                table: "PlayerWeekendStatistics",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerWeekendStatistics_Players_PlayerId",
                table: "PlayerWeekendStatistics");

            migrationBuilder.DropIndex(
                name: "IX_PlayerWeekendStatistics_PlayerId",
                table: "PlayerWeekendStatistics");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "PlayerWeekendStatistics");
        }
    }
}
