﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database2._0.Models
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        public int  PlayerId {get; set; }
        public Player Player { get; set; }
    }
}
