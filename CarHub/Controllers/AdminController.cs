using CarHub.Domain.Services.Interfaces;
using CarHub.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarHub.Controllers
{
    [Authorize]
    public class AdminController : Controller
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
            var currentInventoryList = _inventoryService.GetAllInventoryItems(false);
            return View(currentInventoryList);
        }

        [HttpGet]
        public IActionResult ManageInventory(string id)
        {
            var inventoryViewModel = _inventoryService.GetInventoryById(id);
            return View(inventoryViewModel);
        }

        [HttpPost]
        public IActionResult ManageInventory(InventoryViewModel inventoryViewModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { success = false, errors = ModelState.Values.Where(i => i.Errors.Count > 0) });
            }

            if(inventoryViewModel.Id == null || inventoryViewModel.Id == Guid.Empty)
            {
                //Add new
                var inventoryId = _inventoryService.AddNewInventory(inventoryViewModel);

                if(inventoryId == null)
                {
                    ModelState.AddModelError("error", "Sorry! Something went wrong!");
                    return BadRequest(new { success = false, errors = ModelState.Values.Where(i => i.Errors.Count > 0) });
                }

                //return new id here
                return Ok(new { success = true, inventoryId = inventoryId });
            } else
            {
                //Edit existing
                var result = _inventoryService.EditInventory(inventoryViewModel);
                if(result == false)
                {
                    ModelState.AddModelError("error", "Sorry! Something went wrong!");
                    return BadRequest(new { success = false, errors = ModelState.Values.Where(i => i.Errors.Count > 0) });
                }

                //return new id here
                return Ok(new { success = true, inventoryId = inventoryViewModel.Id });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(FileData fileData)
        {
            await _inventoryService.AddNewMediaToInventoryAsync(fileData, CancellationToken.None);

            return Ok(true);
        }
    }
}
