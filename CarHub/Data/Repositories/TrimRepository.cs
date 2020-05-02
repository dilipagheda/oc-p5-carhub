using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class TrimRepository: ITrimRepository
    {
        private readonly ApplicationDbContext _context;

        public TrimRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Trim> GetAllTrimsByModel(int modelId)
        {
            return _context.Trims.Where(trim => trim.CarModelId == modelId).ToList();
        }
    }
}
