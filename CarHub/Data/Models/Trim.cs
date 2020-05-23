using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class Trim
    {
        public int Id { get; set; }

        public string TrimName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
