using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database2._0.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SendNotifications = table.Column<bool>(nullable: false),
                    GoalsCount = table.Column<int>(nullable: false),
                    WeekendeCounts = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "SeasonSession",
                columns: table => new
                {
                    SeasonYear = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    IsCurrentSeason = table.Column<bool>(nullable: false),
                    CountOfGoals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonSession", x => x.SeasonYear);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamName = table.Column<string>(maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamName);
                });

            migrationBuilder.CreateTable(
                name: "WeekendSession",
                columns: table => new
                {
                    WeekendSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfWeekend = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekendSession", x => x.WeekendSessionId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasonStatistic",
                columns: table => new
                {
                    SeasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeasonYear = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeasonStatistic", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonStatistic_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonStatistic_SeasonSession_SeasonYear",
                        column: x => x.SeasonYear,
                        principalTable: "SeasonSession",
                        principalColumn: "SeasonYear",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerWeekendStatistic",
                columns: table => new
                {
                    PlayerWeekendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Goals = table.Column<int>(nullable: false),
                    Asisstance = table.Column<int>(nullable: false),
                    TeamName = table.Column<string>(nullable: true),
                    WeekendSessionId = table.Column<int>(nullable: false),
                    PlayerSeasonStatisticSeasonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerWeekendStatistic", x => x.PlayerWeekendId);
                    table.ForeignKey(
                        name: "FK_PlayerWeekendStatistic_PlayerSeasonStatistic_PlayerSeasonStatisticSeasonId",
                        column: x => x.PlayerSeasonStatisticSeasonId,
                        principalTable: "PlayerSeasonStatistic",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerWeekendStatistic_Team_TeamName",
                        column: x => x.TeamName,
                        principalTable: "Team",
                        principalColumn: "TeamName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerWeekendStatistic_WeekendSession_WeekendSessionId",
                        column: x => x.WeekendSessionId,
                        principalTable: "WeekendSession",
                        principalColumn: "WeekendSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonStatistic_PlayerId",
                table: "PlayerSeasonStatistic",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonStatistic_SeasonYear",
                table: "PlayerSeasonStatistic",
                column: "SeasonYear");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWeekendStatistic_PlayerSeasonStatisticSeasonId",
                table: "PlayerWeekendStatistic",
                column: "PlayerSeasonStatisticSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWeekendStatistic_TeamName",
                table: "PlayerWeekendStatistic",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWeekendStatistic_WeekendSessionId",
                table: "PlayerWeekendStatistic",
                column: "WeekendSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerWeekendStatistic");

            migrationBuilder.DropTable(
                name: "PlayerSeasonStatistic");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "WeekendSession");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SeasonSession");
        }
    }
}
