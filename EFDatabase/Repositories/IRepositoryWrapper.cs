using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
   public interface IRepositoryWrapper
    {
        IPlayerRepository Player { get; }
        IMatchRepository Match { get; }
        IWeekendSessionRepository WeekendSession { get; }
        IPlayerWeekendStatisticsRepository PlayerWeekendStatistics { get; }
       

    }
}
