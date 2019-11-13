using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Database
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



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=VM-SHP16;Database=SoccerDB;Integrated Security=True");
        //             //@"Data Source=(localdb)\ProjectsV13;Initial Catalog=SoccerDB;");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        // => options.UseSqlite("Data Source=blogging.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Players");
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<PlayerSeasonStatistic>().ToTable("PlayerSeasonStatistics");
            modelBuilder.Entity<PlayerWeekendStatistic>().ToTable("PlayerWeekendStatistics");
            modelBuilder.Entity<SeasonSession>().ToTable("SeasonSessions");
            modelBuilder.Entity<WeekendSession>().ToTable("WeekendSessions");
        }

    }
}
