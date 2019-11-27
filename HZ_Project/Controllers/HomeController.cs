using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFDatabase.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HZ_Project.Controllers
{
    public class HomeController : Controller
    {

        private IMapper _mapper;
        private IRepositoryWrapper _repository;

        public HomeController(IRepositoryWrapper repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }
        public IActionResult Index()
        {
            var player = _repository.Player.SelectTopShoters(3);

            var x = _mapper.Map<IEnumerable<Models.Player>>(player);
            return View(x);
        }
    }
}