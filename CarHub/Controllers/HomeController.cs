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
using CarHub.Domain.Services.Interfaces;

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

        public JsonResult CarModelsByMake(int id)
        {
            var carModels = _carService.GetAllCarModelsByMake(id);
            return new JsonResult(carModels);
        }
        public JsonResult TrimsByModel([FromQuery]int modelId)
        {
            var trims = _carService.GetAllTrimsByModel(modelId);
            return new JsonResult(trims);
        }

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
