using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class CarMakeRepository: ICarMakeRepository
    {
        private readonly ApplicationDbContext _context;

        public CarMakeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarMake> GetAllCarMakes()
        {
            return _context.CarMakes.ToList();
        }

        public void AddNewCarMake(CarMake carMakeObj)
        {
            if(carMakeObj != null)
            {
                _context.CarMakes.Add(carMakeObj);
                _context.SaveChanges();
            }
        }

        public void UpdateCarMake(int id, string carMakeName)
        {
            CarMake carMakeObj =_context.CarMakes.Find(id);
            if(carMakeObj != null)
            {
                carMakeObj.MakeName = carMakeName;
                _context.SaveChanges();
            }
        }

        public void DeleteCarMake(int id)
        {
            CarMake carMakeObj = _context.CarMakes.Find(id);
            if (carMakeObj != null)
            {
                _context.CarMakes.Remove(carMakeObj);
                _context.SaveChanges();
            }
        }

        public IEnumerable<CarMake> FindCarMakeBySearchPhrase(string searchPhrase)
        {
            return _context.CarMakes.Where(c => c.MakeName.ToLower().StartsWith(searchPhrase)).ToList();
        }
    }
}
