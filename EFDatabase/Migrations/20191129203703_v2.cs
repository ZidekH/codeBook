using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDatabase.Migrations
{
    public partial class v2 : Migration
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
                    NickName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    GoalsCount = table.Column<int>(nullable: false),
                    WeekendCounts = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "SeasonSessions",
                columns: table => new
                {
                    SeasonSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeasonYear = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    IsCurrentSeason = table.Column<bool>(nullable: false),
                    CountOfGoals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonSessions", x => x.SeasonSessionId);
                });

            migrationBuilder.CreateTable(
                name: "WeekendSessions",
                columns: table => new
                {
                    WeekendSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfWeekend = table.Column<DateTime>(nullable: false),
                    GoalsOfWeekend = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekendSessions", x => x.WeekendSessionId);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdministratorId);
                    table.ForeignKey(
                        name: "FK_Administrator_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasonStatistics",
                columns: table => new
                {
                    SeasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeasonSessionId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeasonStatistics", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonStatistics_SeasonSessions_SeasonSessionId",
                        column: x => x.SeasonSessionId,
                        principalTable: "SeasonSessions",
                        principalColumn: "SeasonSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: true),
                    WeekendSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_WeekendSessions_WeekendSessionId",
                        column: x => x.WeekendSessionId,
                        principalTable: "WeekendSessions",
                        principalColumn: "WeekendSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HomeTeamTeamId = table.Column<int>(nullable: true),
                    GuestTeamTeamId = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: false),
                    GuestTeamScore = table.Column<int>(nullable: false),
                    WeekendSessionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_GuestTeamTeamId",
                        column: x => x.GuestTeamTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamTeamId",
                        column: x => x.HomeTeamTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_WeekendSessions_WeekendSessionId",
                        column: x => x.WeekendSessionId,
                        principalTable: "WeekendSessions",
                        principalColumn: "WeekendSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerWeekendStatistics",
                columns: table => new
                {
                    PlayerWeekendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Goals = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerWeekendStatistics", x => x.PlayerWeekendId);
                    table.ForeignKey(
                        name: "FK_PlayerWeekendStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_PlayerId",
                table: "Administrator",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GuestTeamTeamId",
                table: "Matches",
                column: "GuestTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamTeamId",
                table: "Matches",
                column: "HomeTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WeekendSessionId",
                table: "Matches",
                column: "WeekendSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonStatistics_PlayerId",
                table: "PlayerSeasonStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonStatistics_SeasonSessionId",
                table: "PlayerSeasonStatistics",
                column: "SeasonSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWeekendStatistics_TeamId",
                table: "PlayerWeekendStatistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_WeekendSessionId",
                table: "Teams",
                column: "WeekendSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "PlayerSeasonStatistics");

            migrationBuilder.DropTable(
                name: "PlayerWeekendStatistics");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SeasonSessions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "WeekendSessions");
        }
    }
}
