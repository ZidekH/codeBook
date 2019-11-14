using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database2._0.Models
{
    class PlayerSeasonStatistic
    {
        [Key]
        public int SeasonId { get; set; }
        public List<PlayerWeekendStatistic> AllWeekendStatistics { get; set; }
        

        public int SeasonSessionId { get; set; }
        public SeasonSession SeasonSession { get; set; }

        //Hráč může a nemusí mít x Season
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
