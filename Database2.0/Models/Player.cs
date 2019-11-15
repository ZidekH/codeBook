using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database2._0.Models
{
    public class Player : ITrackingEntity
    {
        [Key]
        public int PlayerId { get; set; }
        public int PersonalInformationId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public int GoalsCount { get; set; }
        public int WeekendCounts { get; set; }
        public List<PlayerSeasonStatistic> Statistics { get; set; }

        public DateTime Created { get; set; }
        public int CreatedBy { get ; set; }
        public DateTime? Updated { get; set; }
        public int? UpdatedBy { get; set; }
        
    }
}
