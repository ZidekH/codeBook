using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFDatabase.Repositories;
using HZ_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace HZ_Project.Controllers
{
    [Route("{Controler}")]
    public class WeekendSessionController : Controller
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;

        public WeekendSessionController(IRepositoryWrapper repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("matchesByWeekend/{id}")]
        public IActionResult GetWeekendSessionMatches(int id)
        {
            var matchesEf = _repository.WeekendSession.GetById_MatchesIncluded(id).Matches;
            var matches = _mapper.Map<List<Match>>(matchesEf);
            return View("AllMatches", matches);
        }

        [HttpGet]
        [Route("getMatch/{id}")]
        public IActionResult GetMatchProgress(int id)
        {
            var currentMatchEf = _repository.Match.GetById_TeamsPlayerWeekendStsIncluded(id);
            var currentMatch = _mapper.Map<Match>(currentMatchEf);
            return View("MatchProgress", currentMatch);
        }
        [HttpPost]
        [Route("GoalManager")]
        public ActionResult GoalManager(string GoalAction, string playerWeekendStatisticsId, string matchId)
        {
                       
            var playerStat = _repository.PlayerWeekendStatistics.GetById(Convert.ToInt32(playerWeekendStatisticsId));
            var currentMatch = _repository.Match.GetById_TeamsPlayerWeekendStsIncluded(Convert.ToInt32(matchId));

            var isHomeTeam = currentMatch.HomeTeam.PlayersStatsTeam.Contains(playerStat);

            if (GoalAction == "+")
            {
                playerStat.Goals++;
                if (isHomeTeam)
                    currentMatch.HomeTeamScore++;
                else
                    currentMatch.GuestTeamScore++;
            }
            else if (GoalAction == "-")
            {
                if (playerStat.Goals > 0)
                {
                    playerStat.Goals--;
                    if (isHomeTeam && currentMatch.HomeTeamScore >0)
                        currentMatch.HomeTeamScore--;
                    else if(!isHomeTeam && currentMatch.GuestTeamScore >0)
                        currentMatch.GuestTeamScore--;
                }
            }

            _repository.PlayerWeekendStatistics.Update(playerStat);
            _repository.Match.Update(currentMatch);

           return RedirectToAction("getMatch", new { id = Convert.ToInt32(matchId) });

        }
        
        //Get Weekend session
        //Get Match
        //Post Add goal to playerStatistic and return View with goal
                    //Pripise se gol do matche

        //Post Delete goal

        //
    }
}