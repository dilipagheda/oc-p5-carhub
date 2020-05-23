using CarHub.Domain.Services;
using CarHub.Domain.Services.Interfaces;
using CarHub.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInventoryService _inventoryService;

        public HomeController(ILogger<HomeController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currentInventoryList = _inventoryService.GetAllInventoryItems();
            return View(currentInventoryList);
        }

        [HttpGet]
        public IActionResult ViewDetails(string id)
        {
            var inventoryItem = _inventoryService.GetInventoryById(id);
            return View(inventoryItem);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel homeViewModel) { return View(homeViewModel); }

        public JsonResult CarModelsByMake(int id)
        {
            var carModels = _inventoryService.GetAllCarModelsByMake(id);
            return new JsonResult(carModels);
        }

        public JsonResult TrimsByModel([FromQuery]int modelId)
        {
            var trims = _inventoryService.GetAllTrimsByModel(modelId);
            return new JsonResult(trims);
        }

        public IActionResult Privacy() { return View(); }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
