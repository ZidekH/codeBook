using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
    public class Player
    {
        private Guid ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<SeasonStatistic> Statistics { get; set; }



        public Player(string name, string lastName, DateTime dateofBirth)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.LastName = lastName;
            this.DateOfBirth = dateofBirth;
            this.Statistics = new List<SeasonStatistic>();
        }
    }
}
