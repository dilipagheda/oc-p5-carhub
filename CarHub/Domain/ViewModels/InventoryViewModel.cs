using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels
{
    public class InventoryViewModel
    {
        public Guid Id { get; set; }
        public CarViewModel CarViewModel { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeId { get; set; }
        public string PurchaseType { get; set; }
        public int InventoryStatusId { get; set; }
        public string InventoryStatus { get; set; }
        public DateTime AvailableOnDate { get; set; }
        public bool IsFeatured { get; set; }
    }
}
