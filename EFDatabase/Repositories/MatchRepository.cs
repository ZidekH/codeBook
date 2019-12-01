using EFDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
    public class MatchRepository :CommonRepository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext applicationDbContext)
          : base(applicationDbContext)
        { }

        public Match GetById_TeamsPlayerWeekendStsIncluded(int id)
        {
            return table
                .Include(team => team.HomeTeam).ThenInclude(stat => stat.PlayersStatsTeam).ThenInclude(player => player.Player)
                .Include(team => team.GuestTeam).ThenInclude(stat => stat.PlayersStatsTeam).ThenInclude(player => player.Player)
                .Where(x => x.MatchId == id)
                .FirstOrDefault();



        }
    }
}
