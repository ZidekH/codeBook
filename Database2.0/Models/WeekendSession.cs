using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database2._0.Models
{
    class WeekendSession
    {
        [Key]
        public int WeekendSessionId { get; set; }
        public DateTime DateOfWeekend { get; set; }

        public List<PlayerWeekendStatistic> PlayerWeekendStatistics { get; set; }


    }
}
