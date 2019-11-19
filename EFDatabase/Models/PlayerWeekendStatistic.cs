using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFDatabase.Models
{
     public class PlayerWeekendStatistic
    {
        [Key]
        public int PlayerWeekendId { get; set; }
        public int Goals { get; set; }
        public int Asisstance { get; set; }


        public int TeamId { get; set; }
        public Team Team { get; set; }
      

            //PlayerSeasonSession může a nemůsí mít x PlayerWeekendStatistics
        public int? SeasonId { get; set; }
        public PlayerSeasonStatistic PlayerSeasonStatistic { get; set; }


        public int WeekendSessionId {get; set;}
        public WeekendSession WeekendSession { get; set; }

 
    }
}
