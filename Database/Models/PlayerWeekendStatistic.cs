using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    class PlayerWeekendStatistic
    {
        [Key]
        public int PlayerWeekendId { get; set; }
        public int Goals { get; set; }
        public int Asisstance { get; set; }
        public Team Team { get; set; }
        public string TeamName { get; set; }


        //Vazby
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        public int SeasonId { get; set; }
        public PlayerSeasonStatistic PlayerSeasonStatistic { get; set; }

        public int WeekendSessionId {get; set;}
        public WeekendSession WeekendSession { get; set; }

 
    }
}
