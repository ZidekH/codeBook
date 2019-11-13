﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database2._0.Models
{
    class SeasonSession
    {
        [Key]
        public int SeasonYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsCurrentSeason { get; set; }
        public int CountOfGoals { get; set; }

        //public List<PlayerSeasonStatistic> PlayerSeasonsStatistics { get; set; }

    }
}