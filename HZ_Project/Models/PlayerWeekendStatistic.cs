using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HZ_Project.Models
{
    public class PlayerWeekendStatistic
    {

        public int PlayerWeekendId { get; set; }
        public int Goals { get; set; }
        //public int TeamId { get; set; }
        //public Team Team { get; set; }
        public Player Player { get; set; }

 
    }
}
