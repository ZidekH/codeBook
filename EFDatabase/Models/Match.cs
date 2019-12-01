using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Models
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int GuestTeamScore { get; set; }

//Dodáno až po vytvoření DB
        public int WeekendSessionId { get; set; }

        //public WeekendSession WeekendeSession{get; set;}

    }
}
