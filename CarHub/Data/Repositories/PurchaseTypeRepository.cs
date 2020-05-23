using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class PurchaseTypeRepository : IPurchaseTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseTypeRepository(ApplicationDbContext context) { _context = context; }

        public List<PurchaseType> GetAllPurchaseTypes() { return _context.PurchaseTypes.ToList(); }

        public string GetPurchaseTypeById(int id)
        { return _context.PurchaseTypes.Where(x => x.Id == id).Select(x => x.PurchaseTypeName).FirstOrDefault(); }

        public int ManagePurchaseType(PurchaseType purchaseTypeObj)
        {
            if(purchaseTypeObj != null)
            {
                var existingPurchaseTypeObj = _context.PurchaseTypes
                    .Where(x => x.PurchaseTypeName.ToLower().Equals(purchaseTypeObj.PurchaseTypeName.ToLower()))
                    .FirstOrDefault();
                if(existingPurchaseTypeObj != null)
                {
                    existingPurchaseTypeObj.PurchaseTypeName = purchaseTypeObj.PurchaseTypeName;
                    _context.SaveChanges();
                    return existingPurchaseTypeObj.Id;
                } else
                {
                    _context.PurchaseTypes.Add(purchaseTypeObj);
                    _context.SaveChanges();
                    return purchaseTypeObj.Id;
                }
            } else
            {
                return 0;
            }
        }
    }
}
