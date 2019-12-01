using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int GoalsCount { get; set; }
        public int WeekendCounts { get; set; }
        public List<PlayerSeasonStatistic> Statistics { get; set; }

    }
}
