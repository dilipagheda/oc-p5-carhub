using AutoMapper;
using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InventoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Guid? AddInventory(Inventory inventory)
        {
            if(inventory != null)
            {
                _context.InventoryList.Add(inventory);
                _context.SaveChanges();
                return inventory.Id;
            } else
            {
                return null;
            }
        }

        public Inventory GetInventoryDetailsById(string inventoryId)
        {
            if(inventoryId == null)
                return null;

            return _context.InventoryList
                .Where(i => i.Id.ToString() == inventoryId)
                .Include(x => x.Car)
                .ThenInclude(x => x.CarMake)
                .Include(x => x.Car)
                .ThenInclude(x => x.CarModel)
                .Include(x => x.Car)
                .ThenInclude(x => x.Trim)
                .Include(x => x.Car)
                .ThenInclude(x => x.FuelType)
                .Include(x => x.Car)
                .ThenInclude(x => x.BodyType)
                .Include(x => x.Car)
                .ThenInclude(x => x.Color)
                .Include(x => x.Car)
                .ThenInclude(x => x.DriveType)
                .FirstOrDefault();
        }

        public List<Inventory> GetAllInventoryItems()
        { return _context.InventoryList.Include(x => x.Car).Include(x => x.InventoryStatus).ToList(); }

        public List<Inventory> GetUnSoldInventoryItems()
        {
            return _context.InventoryList
                .Where(x => x.InventoryStatus.Status != "Sold")
                .Include(x => x.Car)
                .Include(x => x.InventoryStatus)
                .ToList();
        }

        public void DeleteInventoryById(string inventoryId)
        {
            var inventoryToRemove = _context.InventoryList.Where(x => x.Id.ToString() == inventoryId).FirstOrDefault();
            _context.InventoryList.Remove(inventoryToRemove);
            _context.SaveChanges();
        }

        public void EditInventory(Inventory inventory)
        {
            var inventoryToUpdate = _context.InventoryList
                .Where(x => x.Id.ToString() == inventory.Id.ToString())
                .FirstOrDefault();

            if(inventoryToUpdate != null)
            {
                _mapper.Map(inventory, inventoryToUpdate, typeof(Inventory), typeof(Inventory));
                _context.Entry(inventoryToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
