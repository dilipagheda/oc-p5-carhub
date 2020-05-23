using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class Media
    {
        public Guid Id { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }

        public string Caption { get; set; }
    }
}
