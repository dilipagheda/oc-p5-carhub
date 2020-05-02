using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class CarModelRepository:ICarModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CarModel> GetAllModelsByMake(int makeId)
        {
            return _context.CarModels.Where(m => m.CarMakeId == makeId).ToList();
        }
    }
}
