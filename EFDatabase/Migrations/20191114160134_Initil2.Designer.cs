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
    [Migration("20191114160134_Initil2")]
    partial class Initil2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database2._0.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId");

                    b.HasKey("AdministratorId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("Database2._0.Models.PersonalInformation", b =>
                {
                    b.Property<int>("PersonalInformationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NickName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("SendNotifications");

                    b.HasKey("PersonalInformationId");

                    b.ToTable("PersonalInformation");
                });

            modelBuilder.Entity("Database2._0.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GoalsCount");

                    b.Property<int>("PersonalInformationId");

                    b.Property<int>("WeekendCounts");

                    b.HasKey("PlayerId");

                    b.HasIndex("PersonalInformationId")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Database2._0.Models.PlayerSeasonStatistic", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PlayerId");

                    b.Property<int>("SeasonSessionId");

                    b.HasKey("SeasonId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonSessionId");

                    b.ToTable("PlayerSeasonStatistics");
                });

            modelBuilder.Entity("Database2._0.Models.PlayerWeekendStatistic", b =>
                {
                    b.Property<int>("PlayerWeekendId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Asisstance");

                    b.Property<int>("Goals");

                    b.Property<int?>("SeasonId");

                    b.Property<int>("TeamId");

                    b.Property<int>("WeekendSessionId");

                    b.HasKey("PlayerWeekendId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.HasIndex("WeekendSessionId");

                    b.ToTable("PlayerWeekendStatistics");
                });

            modelBuilder.Entity("Database2._0.Models.SeasonSession", b =>
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

            modelBuilder.Entity("Database2._0.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeamName");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Database2._0.Models.WeekendSession", b =>
                {
                    b.Property<int>("WeekendSessionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfWeekend");

                    b.HasKey("WeekendSessionId");

                    b.ToTable("WeekendSessions");
                });

            modelBuilder.Entity("Database2._0.Models.Administrator", b =>
                {
                    b.HasOne("Database2._0.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database2._0.Models.Player", b =>
                {
                    b.HasOne("Database2._0.Models.PersonalInformation", "PersonalInformation")
                        .WithOne("Player")
                        .HasForeignKey("Database2._0.Models.Player", "PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database2._0.Models.PlayerSeasonStatistic", b =>
                {
                    b.HasOne("Database2._0.Models.Player", "Player")
                        .WithMany("Statistics")
                        .HasForeignKey("PlayerId");

                    b.HasOne("Database2._0.Models.SeasonSession", "SeasonSession")
                        .WithMany("PlayerSeasonsStatistics")
                        .HasForeignKey("SeasonSessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database2._0.Models.PlayerWeekendStatistic", b =>
                {
                    b.HasOne("Database2._0.Models.PlayerSeasonStatistic", "PlayerSeasonStatistic")
                        .WithMany("AllWeekendStatistics")
                        .HasForeignKey("SeasonId");

                    b.HasOne("Database2._0.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Database2._0.Models.WeekendSession", "WeekendSession")
                        .WithMany("PlayerWeekendStatistics")
                        .HasForeignKey("WeekendSessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}