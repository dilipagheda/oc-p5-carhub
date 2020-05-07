using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class PurchaseTypeRepository:IPurchaseTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            return _context.PurchaseTypes.ToList();
        }
    }
}
