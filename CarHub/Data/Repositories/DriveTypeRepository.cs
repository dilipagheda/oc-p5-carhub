using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class DriveTypeRepository : IDriveTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public DriveTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DriveType> GetAllDriveTypes()
        {
            return _context.DriveTypes.ToList();
        }
    }
}
