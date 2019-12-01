using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<PlayerWeekendStatistic> PlayersStatsTeam { get; set; }

        //public int WeekendSessionId { get; set; }
        //public WeekendSession WeekendSession { get; set; }
    }
}
