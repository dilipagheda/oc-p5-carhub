using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class TrimRepository : ITrimRepository
    {
        private readonly ApplicationDbContext _context;

        public TrimRepository(ApplicationDbContext context) { _context = context; }

        public List<Trim> GetAllTrimsByModel(int modelId)
        {
            var carTrims = _context.MakeModelTrims
                .Where(mmt => mmt.CarModelId == modelId)
                .Join(_context.Trims,
                      mmt => mmt.TrimId,
                      tm => tm.Id,
                      (mmt, tm) => new Trim { Id = tm.Id, TrimName = tm.TrimName })
                .Distinct()
                .ToList();

            return carTrims;
        }

        public string GetTrimById(int id)
        { return _context.Trims.Where(x => x.Id == id).Select(x => x.TrimName).FirstOrDefault(); }

        public int ManageTrim(Trim trimObj)
        {
            if(trimObj != null)
            {
                var existingTrim = _context.Trims
                    .Where(x => x.TrimName.ToLower().Equals(trimObj.TrimName.ToLower()))
                    .FirstOrDefault();
                if(existingTrim != null)
                {
                    existingTrim.TrimName = trimObj.TrimName;
                    _context.SaveChanges();
                    return existingTrim.Id;
                } else
                {
                    _context.Trims.Add(trimObj);
                    _context.SaveChanges();
                    return trimObj.Id;
                }
            } else
            {
                return 0;
            }
        }
    }
}
