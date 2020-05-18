using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels
{
    public class FileData
    {
        public IFormFile File { get; set; }
        public string InventoryId { get; set; }
    }
}
