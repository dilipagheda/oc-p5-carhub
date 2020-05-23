using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class InventoryStatusRepository : IInventoryStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryStatusRepository(ApplicationDbContext context) { _context = context; }

        public List<InventoryStatus> GetAllInventoryStatus() { return _context.InventoryStatusList.ToList(); }

        public string GetInventoryStatusById(int id)
        { return _context.InventoryStatusList.Where(x => x.Id == id).Select(x => x.Status).FirstOrDefault(); }

        public int ManageInventoryStatus(InventoryStatus inventoryStatusObj)
        {
            if(inventoryStatusObj != null)
            {
                var existingInventoryStatusObj = _context.InventoryStatusList
                    .Where(x => x.Status.ToLower().Equals(inventoryStatusObj.Status.ToLower()))
                    .FirstOrDefault();
                if(existingInventoryStatusObj != null)
                {
                    existingInventoryStatusObj.Status = inventoryStatusObj.Status;
                    _context.SaveChanges();
                    return existingInventoryStatusObj.Id;
                } else
                {
                    _context.InventoryStatusList.Add(inventoryStatusObj);
                    _context.SaveChanges();
                    return inventoryStatusObj.Id;
                }
            } else
            {
                return 0;
            }
        }
    }
}
