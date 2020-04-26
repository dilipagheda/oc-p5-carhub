using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class InventoryMedia
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public int MediaId { get; set; }
        public Media Media { get; set; }
        public bool IsCoverMedia { get; set; }

    }
}
