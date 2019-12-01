using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFDatabase.Models
{
    public class WeekendSession
    {
        [Key]
        public int WeekendSessionId { get; set; }
        public DateTime DateOfWeekend { get; set; }

        public int GoalsOfWeekend { get; set; }
        //public List<Team> Teams { get; set; }
        public List<Match> Matches { get; set; }



    }
}
