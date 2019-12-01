using EFDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
    public class PlayerWeekendStatisticsRepository : CommonRepository<PlayerWeekendStatistic>, IPlayerWeekendStatisticsRepository
    {
       public PlayerWeekendStatisticsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
