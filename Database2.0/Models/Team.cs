﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database2._0.Models
{
    class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }

    }
}
