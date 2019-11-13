using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database2._0.Models
{
    class Team
    {
        [Key]
        [MaxLength(90)]
        public string TeamName { get; set; }

    }
}
