using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
  
    public class WeekendStatistic
    {
        public DateTime DateOfWeekend { get; set; } 
        public int Goals { get; set; }
        public int Passes { get; set; }
        public Team Team { get; set; }
        //public Enum Place { get; set; }

        
        public WeekendStatistic(DateTime dateOfWeekend,Team team, int goals, int passes)
        {
            this.DateOfWeekend = dateOfWeekend;
            this.Goals = goals;
            this.Passes = passes;
            this.Team = team;
            //this.Place = place;
        }

       
    }
}
