using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database2._0.Models;

namespace Database2._0.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        // načtu si zde Interface IcommonRepository ze kterého pak budu používat basic metody
        public ICommonRepository<Player> CommonRepository { get; set; }

        public PlayerRepository(ApplicationDbContext db)
        {
            CommonRepository = new CommonRepository<Player>(db);
        }

        public Player GetPlayer(int id)
        {
            return CommonRepository.GetById(id);
        }

        public Player GetPlayerByName(string name)
        {
            return CommonRepository.GetAll().FirstOrDefault<Player>(x => x.PersonalInformation.Name == name);
       
    }
}
