using EFDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
    public interface IMatchRepository : ICommonRepository<Match>
    {
        Match GetById_TeamsPlayerWeekendStsIncluded(int id);
    }
}
