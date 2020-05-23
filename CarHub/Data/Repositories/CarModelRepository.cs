using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context) { _context = context; }

        public List<CarModel> GetAllModelsByMake(int makeId)
        {
            var carModels = _context.MakeModelTrims
                .Where(mmt => mmt.CarMakeId == makeId)
                .Join(_context.CarModels,
                      mmt => mmt.CarModelId,
                      cm => cm.Id,
                      (mmt, cm) => new CarModel { Id = cm.Id, ModelName = cm.ModelName })
                .Distinct()
                .ToList();

            return carModels;
        }

        public string GetCarModelNameById(int id)
        { return _context.CarModels.Where(x => x.Id == id).Select(x => x.ModelName).FirstOrDefault(); }

        public int ManageCarModel(CarModel carModelObj)
        {
            if(carModelObj != null)
            {
                var existingCarModel = _context.CarModels
                    .Where(x => x.ModelName.ToLower().Equals(carModelObj.ModelName.ToLower()))
                    .FirstOrDefault();
                if(existingCarModel != null)
                {
                    existingCarModel.ModelName = carModelObj.ModelName;
                    _context.SaveChanges();
                    return existingCarModel.Id;
                } else
                {
                    _context.CarModels.Add(carModelObj);
                    _context.SaveChanges();
                    return carModelObj.Id;
                }
            } else
            {
                return 0;
            }
        }
    }
}
