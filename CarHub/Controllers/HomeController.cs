using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarHub.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeViewModel _carMakesViewModel;
        private readonly List<CarModelViewModel> _carModels;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _carMakesViewModel = new HomeViewModel();

            var items = new List<CarMakeViewModel>(){
                new CarMakeViewModel()
                {
                    Id=1,
                    CarMakeName="Toyota"
                },
                new CarMakeViewModel()
                {
                    Id=2,
                    CarMakeName="BMW"
                },
                new CarMakeViewModel()
                {
                    Id=3,
                    CarMakeName="Mazda"
                },

            };
            _carMakesViewModel.CarMakes = new SelectList(items,"Id","CarMakeName");

            _carModels = new List<CarModelViewModel>()
            {
                new CarModelViewModel()
                {
                    Id=1,
                    CarMakeId=1,
                    CarModelName="Toyota 1"
                },
                new CarModelViewModel()
                {
                    Id=2,
                    CarMakeId=1,
                    CarModelName="Toyota 2"
                }
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_carMakesViewModel);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel homeViewModel)
        {
            return View(_carMakesViewModel);
        }

        [HttpGet]
        public JsonResult CarModelsByMake(int makeId)
        {
            var list = _carModels.Where(model => model.CarMakeId == makeId);
            return new JsonResult(list);
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
