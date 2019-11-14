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

        public DbSet<Administrator> Administrator { get; set; }

        public DbSet<PersonalInformation> PersonalInformation { get; set; }


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
            PersonalInformation PI = new PersonalInformation()
            {
                PersonalInformationId = 1,
                Name = "Jméno",
                LastName = "Příjmení",
                Email = "hjfdsf@fdsfds.cz",
                NickName = "Karlík",
                Password = "fdsfdsfdsfdsf",
               DateOfBirth = new DateTime(1995, 5, 25),
                PhoneNumber = "776789123",
                IsActive = true,
                SendNotifications = true,
            };


            Player player2 = new Player()
            {
                PlayerId = 2,
                GoalsCount = 0,
                WeekendCounts = 0,
                PersonalInformationId =1
                               
            };


            WeekendSession ws1 = new WeekendSession()
            {
                WeekendSessionId = 3,
                DateOfWeekend = new DateTime(2019, 11, 17)

            };

            //WeekendSession ws2 = new WeekendSession()
            //{
            //    WeekendSessionId = 2,
            //    DateOfWeekend = new DateTime(2019, 11, 25)

            //};

            Team t1 = new Team { TeamId=4,TeamName = "černí" };
            //Team t2 = new Team { TeamName = "bílí" };

            PlayerWeekendStatistic pws1 = new PlayerWeekendStatistic()
            {
                PlayerWeekendId = 4,
                Goals = 5,
                Asisstance = 3,
                TeamId = t1.TeamId,
                WeekendSessionId = ws1.WeekendSessionId
                

            };

            //PlayerWeekendStatistic pws2 = new PlayerWeekendStatistic()
            //{
            //    PlayerWeekendId = 2,
            //    Goals = 55,
            //    Asisstance = 1,
            //    Team = t2,
            //    TeamId = t2.TeamId,
            //    WeekendSession = ws2,
            //    WeekendSessionId = ws2.WeekendSessionId
            //};
            //List<PlayerWeekendStatistic> list = new List<PlayerWeekendStatistic>();
            //list.Add(pws1);
            //list.Add(pws2);

            SeasonSession ss1 = new SeasonSession()
            {
                SeasonSessionId = 10,
                SeasonYear = 2019,
                DateFrom = new DateTime(2019, 9, 1),
                DateTo = new DateTime(2020, 1, 1),
                IsCurrentSeason = true,
                CountOfGoals = 0
                
            };
            PlayerSeasonStatistic pss1 = new PlayerSeasonStatistic()
            {
                SeasonId = 7,
                SeasonSessionId = ss1.SeasonSessionId,
                PlayerId = player2.PlayerId

            };

            //List<PlayerSeasonStatistic> psslist = new List<PlayerSeasonStatistic>();
            //psslist.Add(pss1);


            //Player player2 = new Player()
            //{
            //    PlayerId = 2,
            //    Name = "Onřej",
            //    LastName = "Jelínek",
            //    DateOfBirth = new DateTime(1995, 5, 25),
            //    Email = "radim@tabasek",
            //    PhoneNumber = "776789123",
            //    IsActive = true,
            //    SendNotifications = true,
            //    GoalsCount = 0,
            //    WeekendCounts = 0,
            //    Statistics = psslist

            //};


            //SeasonSession ss2 = new SeasonSession()
            //{
            //    SeasonYear = 2018,
            //    DateFrom = new DateTime(2018, 9, 1),
            //    DateTo = new DateTime(2019, 1, 1),
            //    IsCurrentSeason = true,
            //    CountOfGoals = 156
            //};



            modelBuilder.Entity<WeekendSession>().HasData(ws1);
            modelBuilder.Entity<SeasonSession>().HasData(ss1);
            modelBuilder.Entity<Team>().HasData(t1);
            modelBuilder.Entity<PlayerWeekendStatistic>().HasData(pws1);
            modelBuilder.Entity<PlayerSeasonStatistic>().HasData(pss1);
            modelBuilder.Entity<PersonalInformation>().HasData(PI);
      
            modelBuilder.Entity<Player>().HasData(player2);


        }

    }
}
