using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class DriveType
    {
        public int Id { get; set; }

        public string DriveTypeName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
