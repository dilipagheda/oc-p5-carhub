using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class MakeModelTrim
    {
        public long Id { get; set; }

        public int CarMakeId { get; set; }

        public CarMake CarMake { get; set; }

        public int? CarModelId { get; set; }

        public CarModel CarModel { get; set; }

        public int? TrimId { get; set; }

        public Trim Trim { get; set; }
    }
}
