using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels
{
    public class TrimViewModel
    {
        public int Id { get; set; }
        public int CarMakeId { get; set; }
        public int CarModelId { get; set; }
        public string TrimName { get; set; }
    }
}
