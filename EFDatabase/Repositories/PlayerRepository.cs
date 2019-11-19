using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDatabase.Models;

namespace EFDatabase.Repositories
{
    public class PlayerRepository : CommonRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        { }

        public IEnumerable<Player> GetAllPlayersWithPersonalInformation()
        {
            return GetAll();

        }

    }

}
