using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
