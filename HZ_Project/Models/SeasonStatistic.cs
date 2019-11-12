using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
    public class SeasonStatistic
    {
        public int Season { get; set; }
        public List<WeekendStatistic> AllWeekendStatistics { get; set; }

        public SeasonStatistic(int season)
        {
            this.Season = season;
            this.AllWeekendStatistics = new List<WeekendStatistic>();
        }
    }
}
