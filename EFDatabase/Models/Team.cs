using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFDatabase.Models
{
   public class Team
    {
        [Key]

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<PlayerWeekendStatistic> PlayersStatsTeam { get; set; }

        //public int WeekendSessionId { get; set; }
        //public WeekendSession WeekendSession { get; set; }

    }
}
