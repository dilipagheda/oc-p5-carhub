using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class InventoryMedia
    {
        public Guid InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public Guid MediaId { get; set; }

        public Media Media { get; set; }

        public bool IsCoverMedia { get; set; }
    }
}
