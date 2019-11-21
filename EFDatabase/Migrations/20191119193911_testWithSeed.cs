using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDatabase.Migrations
{
    public partial class testWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonalInformation",
                columns: new[] { "PersonalInformationId", "DateOfBirth", "Email", "IsActive", "LastName", "Name", "NickName", "Password", "PhoneNumber", "SendNotifications" },
                values: new object[] { 1, new DateTime(1995, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "hjfdsf@fdsfds.cz", true, "Příjmení", "Jméno", "Karlík", "fdsfdsfdsfdsf", "776789123", true });

            migrationBuilder.InsertData(
                table: "SeasonSessions",
                columns: new[] { "SeasonSessionId", "CountOfGoals", "DateFrom", "DateTo", "IsCurrentSeason", "SeasonYear" },
                values: new object[] { 10, 0, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2019 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "TeamName" },
                values: new object[] { 4, "černí" });

            migrationBuilder.InsertData(
                table: "WeekendSessions",
                columns: new[] { "WeekendSessionId", "DateOfWeekend" },
                values: new object[] { 3, new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PlayerWeekendStatistics",
                columns: new[] { "PlayerWeekendId", "Asisstance", "Goals", "SeasonId", "TeamId", "WeekendSessionId" },
                values: new object[] { 4, 3, 5, null, 4, 3 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "GoalsCount", "PersonalInformationId", "WeekendCounts" },
                values: new object[] { 2, 0, 1, 0 });

            migrationBuilder.InsertData(
                table: "PlayerSeasonStatistics",
                columns: new[] { "SeasonId", "PlayerId", "SeasonSessionId" },
                values: new object[] { 7, 2, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerSeasonStatistics",
                keyColumn: "SeasonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlayerWeekendStatistics",
                keyColumn: "PlayerWeekendId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SeasonSessions",
                keyColumn: "SeasonSessionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WeekendSessions",
                keyColumn: "WeekendSessionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonalInformation",
                keyColumn: "PersonalInformationId",
                keyValue: 1);
        }
    }
}
