using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EFDatabase.Repositories;
using HZ_Project.Models;
using HZ_Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace HZ_Project.Controllers
{

    [Route("Player")]
    public class PlayerController : Controller
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;

        public PlayerController(IRepositoryWrapper repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public IActionResult Index()
        {
            return View("SearchPlayer");
        }

        [HttpPost]
        public IActionResult SearchPlayer([FromForm] SearchPlayer searchPlayer)
        {
            if (ModelState.IsValid)
            {
                string inputValue = searchPlayer.SearchText;
                IEnumerable<EFDatabase.Models.Player> foundedPersonalInformation = _repository.Player.GetByCondition(player => player.Name.Contains(inputValue));
                searchPlayer.ListOfPersonalInformation = _mapper.Map<List<Player>>(foundedPersonalInformation);

                if (searchPlayer.ListOfPersonalInformation.Count() > 5)
                {
                    ViewBag.Answear = "Prosím specifikujte výběr.";
                    return View("SearchPlayer");
                }
                else if (searchPlayer.ListOfPersonalInformation.Count() == 0)
                {
                    ViewBag.Answear = "Nebyl nalezen žádný uživatel.";
                    return View("SearchPlayer");
                }
                return View("SearchPlayer", searchPlayer);
            }
            else
                return StatusCode(400);
        }

        [HttpGet]
        [Route("addPlayer")]
        public ViewResult AddPlayerView()
        {
            return View("AddPlayer");
        }

        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            EFDatabase.Models.Player playerDB = _repository.Player.GetById(id);
            Player player = _mapper.Map<Models.Player>(playerDB);
            return View("UpdatePlayer", player);
        }

        [HttpGet]
        [Route("topShoters/{countOfPlayer}")]
        public PartialViewResult SelectTopShoters(int countOfPlayer)
        {
            IEnumerable<EFDatabase.Models.Player> playersDB = _repository.Player.SelectTopShoters(countOfPlayer);
            IEnumerable<Player> players = _mapper.Map<IEnumerable<Player>>(playersDB);
            return PartialView("Player/TopShoters", players);
        }


        [HttpGet]
        [Route("All")]
        public IActionResult AllPlayer()
        {
            IEnumerable<EFDatabase.Models.Player> playersDB = _repository.Player.GetAll();
            IEnumerable<Player> allplayers = _mapper.Map<IEnumerable<Models.Player>>(playersDB);
            return View("AllPlayers", allplayers);
        }

        [HttpPost]
        [Route("AddPlayer")]
        public IActionResult CreatePlayer([FromForm]Player player)
        {

            if (ModelState.IsValid)
            {
                EFDatabase.Models.Player playerDB = _mapper.Map<EFDatabase.Models.Player>(player);
                _repository.Player.Insert(playerDB);
                _repository.Player.Save();

                return View();
            }
            else
                return StatusCode(400);
        }

        [HttpPost]
        [Route("UpdatePlayer")]
        public IActionResult UpdatePlayer([FromForm]Player player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var playerDB = _mapper.Map<EFDatabase.Models.Player>(player);
                    _repository.Player.Update(playerDB);
                    _repository.Player.Save();

                    return View();
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
                throw new Exception("Update player failed");

            }
        }

    }
}