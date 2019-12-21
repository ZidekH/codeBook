using EFDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
    public interface IPlayerRepository : ICommonRepository<Player>
    {
        IEnumerable<Player> SelectTopShoters(int countOfPlayers);

       


    }
}
