using EFDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
   public interface IWeekendSessionRepository : ICommonRepository<WeekendSession>
    {
        WeekendSession GetById_MatchesIncluded(int id);
    }
}
