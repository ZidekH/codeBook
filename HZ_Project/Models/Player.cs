using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<SeasonStatistic> Statistics { get; set; }

    }
}
