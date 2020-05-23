using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly ApplicationDbContext _context;

        public ColorRepository(ApplicationDbContext context) { _context = context; }

        public List<Color> GetAllColors() { return _context.Colors.ToList(); }

        public string GetColorById(int id)
        { return _context.Colors.Where(x => x.Id == id).Select(x => x.ColorName).FirstOrDefault(); }

        public int ManageColor(Color colorObj)
        {
            if(colorObj != null)
            {
                var existingColor = _context.Colors
                    .Where(x => x.ColorName.ToLower().Equals(colorObj.ColorName.ToLower()))
                    .FirstOrDefault();
                if(existingColor != null)
                {
                    existingColor.ColorName = colorObj.ColorName;
                    _context.SaveChanges();
                    return existingColor.Id;
                } else
                {
                    _context.Colors.Add(colorObj);
                    _context.SaveChanges();
                    return colorObj.Id;
                }
            } else
            {
                return 0;
            }
        }
    }
}
