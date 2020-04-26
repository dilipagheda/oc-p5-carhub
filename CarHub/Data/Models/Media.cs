using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class Media
    {
        public int Id { get; set; }
        public char MediaType { get; set; }
        public string MediaName { get; set; }
        public string Caption { get; set; }
    }
}
