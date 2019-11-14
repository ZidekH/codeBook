using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database2._0.Migrations
{
    public partial class Initil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    PersonalInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SendNotifications = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.PersonalInformationId);
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
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "WeekendSessions",
                columns: table => new
                {
                    WeekendSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfWeekend = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekendSessions", x => x.WeekendSessionId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(nullable: false),
                    GoalsCount = table.Column<int>(nullable: false),
                    WeekendCounts = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformation",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasonStatistics",
                columns: table => new
                {
                    SeasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeasonSessionId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeasonStatistics", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonStatistics_SeasonSessions_SeasonSessionId",
                        column: x => x.SeasonSessionId,
                        principalTable: "SeasonSessions",
                        principalColumn: "SeasonSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerWeekendStatistics",
                columns: table => new
                {
                    PlayerWeekendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Goals = table.Column<int>(nullable: false),
                    Asisstance = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    SeasonId = table.Column<int>(nullable: true),
                    WeekendSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerWeekendStatistics", x => x.PlayerWeekendId);
                    table.ForeignKey(
                        name: "FK_PlayerWeekendStatistics_PlayerSeasonStatistics_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "PlayerSeasonStatistics",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerWeekendStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerWeekendStatistics_WeekendSessions_WeekendSessionId",
                        column: x => x.WeekendSessionId,
                        principalTable: "WeekendSessions",
                        principalColumn: "WeekendSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PersonalInformationId",
                table: "Players",
                column: "PersonalInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonStatistics_PlayerId",
                table: "PlayerSeasonStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonStatistics_SeasonSessionId",
                table: "PlayerSeasonStatistics",
                column: "SeasonSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWeekendStatistics_SeasonId",
                table: "PlayerWeekendStatistics",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWeekendStatistics_TeamId",
                table: "PlayerWeekendStatistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWeekendStatistics_WeekendSessionId",
                table: "PlayerWeekendStatistics",
                column: "WeekendSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerWeekendStatistics");

            migrationBuilder.DropTable(
                name: "PlayerSeasonStatistics");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "WeekendSessions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SeasonSessions");

            migrationBuilder.DropTable(
                name: "PersonalInformation");
        }
    }
}
