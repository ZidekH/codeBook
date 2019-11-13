﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    class PlayerSeasonStatistic
    {
        [Key]
        public int SeasonId { get; set; }
        public List<PlayerWeekendStatistic> AllWeekendStatistics { get; set; }


        public int SeasonYear { get; set; }
        public SeasonSession SeasonSession { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
    }
}