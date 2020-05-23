using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarHub.Data.Repositories
{
    public class CarMakeRepository : ICarMakeRepository
    {
        private readonly ApplicationDbContext _context;

        public CarMakeRepository(ApplicationDbContext context) { _context = context; }

        public IEnumerable<CarMake> GetAllCarMakes() { return _context.CarMakes.ToList(); }

        public int ManageCarMake(CarMake carMakeObj)
        {
            if(carMakeObj != null)
            {
                var existingCarMake = _context.CarMakes
                    .Where(x => x.MakeName.ToLower().Equals(carMakeObj.MakeName.ToLower()))
                    .FirstOrDefault();
                if(existingCarMake != null)
                {
                    existingCarMake.MakeName = carMakeObj.MakeName;
                    _context.SaveChanges();
                    return existingCarMake.Id;
                } else
                {
                    _context.CarMakes.Add(carMakeObj);
                    _context.SaveChanges();
                    return carMakeObj.Id;
                }
            } else
            {
                return 0;
            }
        }

        public void DeleteCarMake(int id)
        {
            CarMake carMakeObj = _context.CarMakes.Find(id);
            if(carMakeObj != null)
            {
                _context.CarMakes.Remove(carMakeObj);
                _context.SaveChanges();
            }
        }

        public string GetCarMakeNameById(int id)
        { return _context.CarMakes.Where(x => x.Id == id).Select(x => x.MakeName).FirstOrDefault(); }
    }
}
