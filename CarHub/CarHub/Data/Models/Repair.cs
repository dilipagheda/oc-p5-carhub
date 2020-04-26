using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
