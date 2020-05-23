using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class FuelType
    {
        public int Id { get; set; }

        public string FuelTypeName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
