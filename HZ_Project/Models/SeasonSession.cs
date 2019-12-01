using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HZ_Project.Models
{
   public class SeasonSession
    {
        
        public int SeasonSessionId { get; set; }
        public int SeasonYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsCurrentSeason { get; set; }
        public int CountOfGoals { get; set; }

        public List<WeekendSession> WeekendSessions = new List<WeekendSession>();



    }
}
