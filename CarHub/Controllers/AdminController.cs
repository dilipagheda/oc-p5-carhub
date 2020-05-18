using CarHub.Domain.Services.Interfaces;
using CarHub.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Controllers
{
    public class AdminController: Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IInventoryService _inventoryService;

        public AdminController(ILogger<AdminController> logger, IInventoryService inventoryService)
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
        public IActionResult AddNewInventory()
        {
            var inventoryViewModel = _inventoryService.GetInventoryById(null);
            return View(inventoryViewModel);
        }

        //[HttpGet]
        //public IActionResult EditInventory(string id)
        //{
        //    var inventoryViewModel = _inventoryService.GetInventoryById(id);
        //    inventoryViewModel.Id = 
        //    return View(inventoryViewModel);
        //}

        [HttpPost]
        public IActionResult AddNewInventory(InventoryViewModel inventoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, errors = ModelState.Values.Where(i => i.Errors.Count > 0) });
            }

            var inventoryId = _inventoryService.AddNewInventory(inventoryViewModel);

            if(inventoryId == null)
            {
                ModelState.AddModelError("error", "Sorry! Something went wrong!");
                return BadRequest(new { success = false, errors = ModelState.Values.Where(i => i.Errors.Count > 0) });
            }

            //return new id here
            return Ok(new { success=true, inventoryId = inventoryId});
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(FileData fileData)
        {
            await _inventoryService.AddNewMediaToInventoryAsync(fileData);
           
            return Ok(true);
        }

        public IActionResult Delete(string id)
        {
            _inventoryService.DeleteInventoryById(id);
            return RedirectToAction("Index");
        }
    }
}
