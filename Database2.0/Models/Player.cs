using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database2._0.Models
{
    class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool SendNotifications { get; set; }
        public int GoalsCount { get; set; }
        public int WeekendeCounts { get; set; }
        
       
        public List<PlayerSeasonStatistic> Statistics { get; set; }
    }
}
