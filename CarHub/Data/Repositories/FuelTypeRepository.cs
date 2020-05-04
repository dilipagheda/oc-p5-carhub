using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class FuelTypeRepository: IFuelTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public FuelTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FuelType> GetAllFuelTypes()
        {
            return _context.FuelTypes.ToList();
        }
    }
}
