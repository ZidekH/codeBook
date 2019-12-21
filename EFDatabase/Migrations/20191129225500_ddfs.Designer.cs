﻿// <auto-generated />
using System;
using EFDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDatabase.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191129225500_ddfs")]
    partial class ddfs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDatabase.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId");

                    b.HasKey("AdministratorId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("EFDatabase.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GuestTeamScore");

                    b.Property<int?>("GuestTeamTeamId");

                    b.Property<int>("HomeTeamScore");

                    b.Property<int?>("HomeTeamTeamId");

                    b.Property<int?>("WeekendSessionId");

                    b.HasKey("MatchId");

                    b.HasIndex("GuestTeamTeamId");

                    b.HasIndex("HomeTeamTeamId");

                    b.HasIndex("WeekendSessionId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("EFDatabase.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<int>("GoalsCount");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("NickName");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("WeekendCounts");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EFDatabase.Models.PlayerSeasonStatistic", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId");

                    b.Property<int>("SeasonSessionId");

                    b.HasKey("SeasonId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonSessionId");

                    b.ToTable("PlayerSeasonStatistics");
                });

            modelBuilder.Entity("EFDatabase.Models.PlayerWeekendStatistic", b =>
                {
                    b.Property<int>("PlayerWeekendId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Goals");

                    b.Property<int?>("PlayerId");

                    b.Property<int>("TeamId");

                    b.HasKey("PlayerWeekendId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayerWeekendStatistics");
                });

            modelBuilder.Entity("EFDatabase.Models.SeasonSession", b =>
                {
                    b.Property<int>("SeasonSessionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountOfGoals");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<bool>("IsCurrentSeason");

                    b.Property<int>("SeasonYear");

                    b.HasKey("SeasonSessionId");

                    b.ToTable("SeasonSessions");
                });

            modelBuilder.Entity("EFDatabase.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeamName");

                    b.Property<int>("WeekendSessionId");

                    b.HasKey("TeamId");

                    b.HasIndex("WeekendSessionId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EFDatabase.Models.WeekendSession", b =>
                {
                    b.Property<int>("WeekendSessionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfWeekend");

                    b.Property<int>("GoalsOfWeekend");

                    b.HasKey("WeekendSessionId");

                    b.ToTable("WeekendSessions");
                });

            modelBuilder.Entity("EFDatabase.Models.Administrator", b =>
                {
                    b.HasOne("EFDatabase.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFDatabase.Models.Match", b =>
                {
                    b.HasOne("EFDatabase.Models.Team", "GuestTeam")
                        .WithMany()
                        .HasForeignKey("GuestTeamTeamId");

                    b.HasOne("EFDatabase.Models.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamTeamId");

                    b.HasOne("EFDatabase.Models.WeekendSession")
                        .WithMany("Matches")
                        .HasForeignKey("WeekendSessionId");
                });

            modelBuilder.Entity("EFDatabase.Models.PlayerSeasonStatistic", b =>
                {
                    b.HasOne("EFDatabase.Models.Player", "Player")
                        .WithMany("Statistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFDatabase.Models.SeasonSession", "SeasonSession")
                        .WithMany("PlayerSeasonsStatistics")
                        .HasForeignKey("SeasonSessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFDatabase.Models.PlayerWeekendStatistic", b =>
                {
                    b.HasOne("EFDatabase.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("EFDatabase.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFDatabase.Models.Team", b =>
                {
                    b.HasOne("EFDatabase.Models.WeekendSession", "WeekendSession")
                        .WithMany()
                        .HasForeignKey("WeekendSessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}