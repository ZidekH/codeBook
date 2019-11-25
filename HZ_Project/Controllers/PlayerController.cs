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
    public class PlayerController : Controller
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;

        public PlayerController(IRepositoryWrapper repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [Route("")]
        public ViewResult AddPlayerView()
        {
            return View("AddPlayer");
        }



        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            var player = _repository.Player.GetInfoById_relatedData(id);

             var x = _mapper.Map<Models.Player>(player);
             return View("UpdatePlayer", x);

            //return Ok(x);
         
        }


        [HttpGet]
        [Route("All")]
        public IActionResult AllPlayer()
        {
            var player = _repository.Player.GetAllPlayersWithPersonalInformation();


            var x = _mapper.Map<IEnumerable<Models.Player>>(player);
            return View("AllPlayers", x);

            //return Ok(x);

        }

        [HttpPost]
        [Route("AddPlayer")]
        public IActionResult CreatePlayer([FromForm]Player player)
        {
            //ToDo udělat asynchroně
            try
            {
                if (ModelState.IsValid)
                {
                    var playerDB = _mapper.Map<EFDatabase.Models.Player>(player);
                    _repository.Player.Insert(playerDB);
                    _repository.Player.Save();

                    return View();
                }
                return StatusCode(101);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                throw new Exception("Chyba");
                
            }
        }


        [HttpPost]
        [Route("UpdatePlayer")]
        public IActionResult UpdatePlayer([FromForm]Player player)
        {
            //ToDo udělat asynchroně
            try
            {
                if (ModelState.IsValid)
                {
                    var playerDB = _mapper.Map<EFDatabase.Models.Player>(player);
                    _repository.Player.Update(playerDB);
                    _repository.Player.Save();

                    return View();
                }
                return StatusCode(101);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                throw new Exception("Chyba");

            }
        }

        //public IActionResult Index()
        //{

        //    //PlayerS.Statistics.Add(stat);

        //    return View();
        //}


    }
}