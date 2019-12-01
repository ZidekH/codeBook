using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        
        public int HomeTeamScore { get; set; }
        public int GuestTeamScore { get; set; }

        public int WeekendSessionId { get; set; }


    }
}
