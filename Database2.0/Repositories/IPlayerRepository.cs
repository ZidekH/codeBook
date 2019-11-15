using Database2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database2._0.Repositories
{
    public interface IPlayerRepository
    {
       Player GetPlayer(int id);
       Player GetPlayerByName(string Name);

        
        //If UpdateWeekend (Přepočítat CoutOfWeekendGoals)
        //If UpdateSeason (Přepočítat goly v dané sezoně a zapsat je k hráči
        



        

        

    }
}
