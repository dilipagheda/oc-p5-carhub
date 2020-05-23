using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface IPurchaseTypeRepository
    {
        public List<PurchaseType> GetAllPurchaseTypes();

        public string GetPurchaseTypeById(int id);

        public int ManagePurchaseType(PurchaseType purchaseTypeObj);
    }
}
