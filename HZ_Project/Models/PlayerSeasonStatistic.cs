﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HZ_Project.Models
{
   public class PlayerSeasonStatistic
    {
        public int SeasonId { get; set; }
        public List<PlayerWeekendStatistic> AllWeekendStatistics { get; set; }
        
        public int SeasonSessionId { get; set; }
        public SeasonSession SeasonSession { get; set; }

        public Player Player { get; set; }
    }
}
