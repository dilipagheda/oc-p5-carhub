using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface IRepairRepository
    {
        public IEnumerable<Repair> GetAllRepairs();

        public void AddNewRepair(Repair repairObj);

        public void EditRepair(string carId, Repair repairObj);

        public Repair GetRepairDetailsByCarId(string carId);

        public void DeleteRepairDetailsByCarId(string carId);
    }
}
