using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface IInventoryStatusRepository
    {
        public List<InventoryStatus> GetAllInventoryStatus();

        public string GetInventoryStatusById(int id);

        public int ManageInventoryStatus(InventoryStatus inventoryStatusObj);
    }
}
