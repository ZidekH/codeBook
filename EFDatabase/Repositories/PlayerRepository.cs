using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDatabase.Repositories
{
    public class PlayerRepository : CommonRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        { }

        //public IEnumerable<Player> GetAllPlayersWith()
        //{
        //    return table.Include(x => x.).ToList();

        //}

        //public Player GetInfoById_relatedData(int id)
        //{
        //    //Todo: Not working with DBset Table here!!!!!!
        //    return table.Include(x => x.).Where(y => y.Id == id).FirstOrDefault();
        //}

        public IEnumerable<Player> SelectTopShoters(int countOfPlayers)
        {
            return table.OrderByDescending(y => y.GoalsCount).Take(countOfPlayers);
        }

    }

}
