using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public Car Car { get; set; }

        public DateTime? SaleDate { get; set; }

        public decimal SalePrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal PurchasePrice { get; set; }

        public int PurchaseTypeId { get; set; }

        public PurchaseType PurchaseType { get; set; }

        public int InventoryStatusId { get; set; }

        public InventoryStatus InventoryStatus { get; set; }

        public DateTime LotDate { get; set; }

        public bool IsFeatured { get; set; }
    }
}
