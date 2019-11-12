using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HZ_Project.Models;
using Microsoft.AspNetCore.Mvc;


namespace HZ_Project.Controllers
{
    public class PlayerController : Controller
    {
       
       
        public IActionResult Index()
        {
            Player PlayerS = new Player("karel", "ŠÍpek", new DateTime(2019, 12, 1));
            Team team = new Team("Žluty");
            SeasonStatistic stat = new SeasonStatistic(5);
            WeekendStatistic wek = new WeekendStatistic(new DateTime(2016, 12, 12), team, 45, 32);
            stat.AllWeekendStatistics.Add(wek);

            PlayerS.Statistics.Add(stat);

            return View(PlayerS);
        }

       
    }
}