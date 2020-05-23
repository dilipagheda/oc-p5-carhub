using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public FuelTypeRepository(ApplicationDbContext context) { _context = context; }

        public List<FuelType> GetAllFuelTypes() { return _context.FuelTypes.ToList(); }

        public string GetFuelTypeById(int id)
        { return _context.FuelTypes.Where(x => x.Id == id).Select(x => x.FuelTypeName).FirstOrDefault(); }

        public int ManageFuelType(FuelType fuelTypeObj)
        {
            if(fuelTypeObj != null)
            {
                var exisingFuelType = _context.FuelTypes
                    .Where(x => x.FuelTypeName.ToLower().Equals(fuelTypeObj.FuelTypeName.ToLower()))
                    .FirstOrDefault();
                if(exisingFuelType != null)
                {
                    exisingFuelType.FuelTypeName = fuelTypeObj.FuelTypeName;
                    _context.SaveChanges();
                    return exisingFuelType.Id;
                } else
                {
                    _context.FuelTypes.Add(fuelTypeObj);
                    _context.SaveChanges();
                    return fuelTypeObj.Id;
                }
            } else
            {
                return 0;
            }
        }
    }
}
