using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarHub.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarHub.Domain.Services;

namespace CarHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var carMakesViewModel = _carService.GetAllCarMakes();

            var homeViewModel = new HomeViewModel()
            {
                CarMakes = new SelectList(carMakesViewModel, "Id", "CarMakeName")
            };
            return View(homeViewModel);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel homeViewModel)
        {
            return View(homeViewModel);
        }

        //public JsonResult CarModelsByMake(int makeId)
        //{
        //    var list = _carService.Where(model => model.CarMakeId == makeId);
        //    return new JsonResult(list);
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
