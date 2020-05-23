using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface IColorRepository
    {
        public List<Color> GetAllColors();

        public string GetColorById(int id);

        public int ManageColor(Color colorObj);
    }
}
