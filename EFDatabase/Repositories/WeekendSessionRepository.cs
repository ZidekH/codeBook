using EFDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
    public class WeekendSessionRepository: CommonRepository<WeekendSession>, IWeekendSessionRepository
    {
        public WeekendSessionRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
        { }

        public WeekendSession GetById_MatchesIncluded(int id)
        {
            return table
                .Include(match => match.Matches).ThenInclude(team => team.GuestTeam).ThenInclude(list => list.PlayersStatsTeam)
                .Include(match => match.Matches).ThenInclude(team => team.HomeTeam).ThenInclude(list => list.PlayersStatsTeam)
                .Where(x => x.WeekendSessionId == id)
                .FirstOrDefault();
              
                 
        }
    }
}
