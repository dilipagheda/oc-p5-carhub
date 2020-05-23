using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class CarMake
    {
        public int Id { get; set; }

        public string MakeName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
