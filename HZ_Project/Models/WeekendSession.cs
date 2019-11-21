using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HZ_Project.Models
{
    public class WeekendSession
    {
        public int WeekendSessionId { get; set; }
        public DateTime DateOfWeekend { get; set; }
        public List<PlayerWeekendStatistic> PlayerWeekendStatistics { get; set; }


    }
}
