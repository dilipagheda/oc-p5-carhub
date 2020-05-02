using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels
{
    public class CarModelViewModel
    {
        public int Id { get; set; }
        public int CarMakeId { get; set; }
        public string CarModelName { get; set; }
    }
}
