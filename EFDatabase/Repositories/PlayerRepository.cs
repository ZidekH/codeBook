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

        public IEnumerable<Player> GetAllPlayersWithPersonalInformation()
        {
            return table.Include(x => x.PersonalInformation).ToList();

        }

        public Player GetInfoById_relatedData(int id)
        {
            //Todo: Not working with DBset Table here!!!!!!
            return table.Include(x => x.PersonalInformation).Where(y => y.PersonalInformationId == id).FirstOrDefault();
        }

    }

}
