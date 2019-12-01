using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDatabase.Models
{
   public class PlayerSeasonStatistic
    {
        [Key]

        public int SeasonId { get; set; }

        public int SeasonSessionId { get; set; }
        public SeasonSession SeasonSession { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
               
    }
}
