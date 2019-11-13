using Database2._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database2._0
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        //public ApplicationDbContext() { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerSeasonStatistic> PlayerSeasonStatistics { get; set; }

        public DbSet<PlayerWeekendStatistic> PlayerWeekendStatistics { get; set; }

        public DbSet<SeasonSession> SeasonSessions { get; set; }
        public DbSet<WeekendSession> WeekendSessions { get; set; }


        //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        //{
        //    public ApplicationDbContext CreateDbContext(string[] args)
        //    {
        //        Microsoft.Extensions.Configuration.IConfigurationRoot configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../HZ_Project/appsettings.json").Build();
        //        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //        var connectionString = configuration.GetConnectionString("DatabaseConnection");
        //        builder.UseSqlServer(connectionString);
        //        return new ApplicationDbContext(builder.Options);
        //    }
        //}



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=VM-SHP16;Database=SoccerDB;Integrated Security=True");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            WeekendSession ws1 = new WeekendSession()
            {
                WeekendSessionId = 1,
                DateOfWeekend = new DateTime(2019, 11, 17)

            };

            WeekendSession ws2 = new WeekendSession()
            {
                WeekendSessionId = 2,
                DateOfWeekend = new DateTime(2019, 11, 25)

            };

            Team t1 = new Team { TeamName = "černí" };
            Team t2 = new Team { TeamName = "bílí" };

            PlayerWeekendStatistic pws1 = new PlayerWeekendStatistic()
            {
                PlayerWeekendId = 1,
                Goals = 5,
                Asisstance = 3,
                Team = t1,
                TeamName = t1.TeamName,
                WeekendSession = ws1,
                WeekendSessionId = ws1.WeekendSessionId
            };

            PlayerWeekendStatistic pws2 = new PlayerWeekendStatistic()
            {
                PlayerWeekendId = 2,
                Goals = 55,
                Asisstance = 1,
                Team = t2,
                TeamName = t2.TeamName,
                WeekendSession = ws2,
                WeekendSessionId = ws2.WeekendSessionId
            };
            List<PlayerWeekendStatistic> list = new List<PlayerWeekendStatistic>();
            list.Add(pws1);
            list.Add(pws2);

            SeasonSession ss1 = new SeasonSession()
            {
                SeasonYear = 2019,
                DateFrom = new DateTime(2019, 9, 1),
                DateTo = new DateTime(2020, 1, 1),
                IsCurrentSeason = true,
                CountOfGoals = 0
            };
            PlayerSeasonStatistic pss1 = new PlayerSeasonStatistic()
            {
                SeasonId = 1,
                AllWeekendStatistics = list,
                SeasonYear = ss1.SeasonYear,
                SeasonSession = ss1
            };

            List<PlayerSeasonStatistic> psslist = new List<PlayerSeasonStatistic>();
            psslist.Add(pss1);


            Player player2 = new Player()
            {
                PlayerId = 2,
                Name = "Onřej",
                LastName = "Jelínek",
                DateOfBirth = new DateTime(1995, 5, 25),
                Email = "radim@tabasek",
                PhoneNumber = "776789123",
                IsActive = true,
                SendNotifications = true,
                GoalsCount = 0,
                WeekendeCounts = 0,
                Statistics = psslist
                
            };

        

         

            SeasonSession ss2 = new SeasonSession()
            {
                SeasonYear = 2018,
                DateFrom = new DateTime(2018, 9, 1),
                DateTo = new DateTime(2019, 1, 1),
                IsCurrentSeason = true,
                CountOfGoals = 156
            };

          
        

        



        

            modelBuilder.Entity<WeekendSession>().HasData(ws1, ws2);
            modelBuilder.Entity<SeasonSession>().HasData(ss1, ss2);
            modelBuilder.Entity<Team>().HasData(t1, t2);
            modelBuilder.Entity<PlayerWeekendStatistic>().HasData(pws1, pws2);
            modelBuilder.Entity<PlayerSeasonStatistic>().HasData(pss1);

            modelBuilder.Entity<Player>().HasData(player2);

          


           
        
         





            //modelBuilder.Entity<Player>().ToTable("Players");
            //modelBuilder.Entity<Team>().ToTable("Teams");
            //modelBuilder.Entity<PlayerSeasonStatistic>().ToTable("PlayerSeasonStatistics");
            //modelBuilder.Entity<PlayerWeekendStatistic>().ToTable("PlayerWeekendStatistics");
            //modelBuilder.Entity<SeasonSession>().ToTable("SeasonSessions");
            //modelBuilder.Entity<WeekendSession>().ToTable("WeekendSessions");
        }

    }
}
