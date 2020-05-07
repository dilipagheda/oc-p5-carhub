using CarHub.Domain.Services.Interfaces;
using CarHub.Domain.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Controllers
{
    public class AdminController: Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ICarService _carService;

        public AdminController(ILogger<AdminController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var carMakesViewModel = _carService.GetAllCarMakes();
            var bodyTypesViewModel = _carService.GetAllBodyTypes();
            var fuelTypesViewModel = _carService.GetAllFuelTypes();
            var driveTypesViewModel = _carService.GetAllDriveTypes();
            var purchaseTypesViewModel = _carService.GetAllPurchaseTypes();

            var addNewCarViewModel = new AddNewCarViewModel()
            {
                CarMakes = new SelectList(carMakesViewModel, "Id", "CarMakeName"),
                BodyTypes = new SelectList(bodyTypesViewModel, "Id", "BodyTypeName"),
                FuelTypes = new SelectList(fuelTypesViewModel, "Id", "FuelTypeName"),
                DriveTypes = new SelectList(driveTypesViewModel, "Id", "DriveTypeName"),
                PurchaseTypes = new SelectList(purchaseTypesViewModel, "Id", "PurchaseTypeName")
            };
            return View(addNewCarViewModel);
        }

        [HttpPost]
        public IActionResult Index(AddNewCarViewModel addNewCarViewModel)
        {
            return View();
        }

    }
}
