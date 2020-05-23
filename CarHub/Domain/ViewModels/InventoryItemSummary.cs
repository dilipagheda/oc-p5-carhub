using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels
{
    public class InventoryItemSummary
    {
        public string Image { get; set; }

        public string Price { get; set; }

        public string HeadLine { get; set; }

        public string InventoryId { get; set; }
    }
}
