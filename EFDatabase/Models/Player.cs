using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFDatabase.Models
{
    public class Player /*: ITrackingEntity*/
    {
        [Key]
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
        //public DateTime Created { get; set; }
        //public int CreatedBy { get ; set; }
        //public DateTime? Updated { get; set; }
        //public int? UpdatedBy { get; set; }

    }
}
