using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
    public class Player
    {
        public int ID { get; set; }
        public int PersonalInformationId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public int GoalsCount { get; set; }
        public int WeekendCounts { get; set; }
        public List<PlayerSeasonStatistic> Statistics { get; set; }

    }
}
