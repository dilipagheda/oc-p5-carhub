using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class BodyTypeRepository: IBodyTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public BodyTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BodyType> GetAllBodyTypes()
        {
            return _context.BodyTypes.ToList();
        }
    }
}
