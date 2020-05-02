using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels
{
    public class HomeViewModel
    {
        [DisplayName("Make")]
        public int CarMakeId { get; set; }
        public SelectList CarMakes { get; set; }

        [DisplayName("Model")]
        public int CarModelId { get; set; }
        public SelectList CarModels { get; set; }

        [DisplayName("Trim")]
        public int TrimId { get; set; }
        public SelectList Trims { get; set; }
    }
}
