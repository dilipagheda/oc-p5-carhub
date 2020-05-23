using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        public Guid? AddInventory(Inventory inventory);

        public void EditInventory(Inventory inventory);

        public Inventory GetInventoryDetailsById(string inventoryId);

        public List<Inventory> GetAllInventoryItems();

        public void DeleteInventoryById(string inventoryId);

        public List<Inventory> GetUnSoldInventoryItems();
    }
}
