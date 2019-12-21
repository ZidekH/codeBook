using EFDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }


        public ApplicationDbContext() { }


        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerSeasonStatistic> PlayerSeasonStatistics { get; set; }
        public DbSet<PlayerWeekendStatistic> PlayerWeekendStatistics { get; set; }
        public DbSet<SeasonSession> SeasonSessions { get; set; }
        public DbSet<WeekendSession> WeekendSessions { get; set; }
        public DbSet<Administrator> Administrator { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=WIN-6HUOGQHSQOD;Database=SoccerDB;Integrated Security=True");
        }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
          
        }

    }
}
