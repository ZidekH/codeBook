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

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public Player Player { get; set; }


        //public int WeekendSessionId { get; set; }
        //public WeekendSession WeekendSession { get; set; }

    }
}
