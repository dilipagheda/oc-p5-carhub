using AutoMapper;
using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Car> GetAllCars() { return _context.Cars.ToList(); }

        public Car GetCarById(string id)
        { return _context.Cars.Where(c => c.Id.ToString().Equals(id)).FirstOrDefault(); }

        public Guid? AddNewCar(Car carObj)
        {
            if(carObj != null)
            {
                _context.Cars.Add(carObj);
                _context.SaveChanges();
                return carObj.Id;
            } else
            {
                return null;
            }
        }

        public void DeleteCarById(string id)
        {
            var carToRemove = _context.Cars.Where(x => x.Id.ToString().Equals(id)).FirstOrDefault();
            _context.Cars.Remove(carToRemove);
            _context.SaveChanges();
        }

        public void EditCar(string carId, Car carObj)
        {
            if(carObj == null)
            {
                return;
            }

            var currentCarObj = GetCarById(carId);
            if(currentCarObj != null)
            {
                _mapper.Map(carObj, currentCarObj, typeof(Car), typeof(Car));
                _context.Entry(currentCarObj).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void AddMakeModelTrim(int makeId, int modelId, int trimId)
        {
            if(makeId > 0 && modelId > 0 && trimId > 0)
            {
                var currentItem = _context.MakeModelTrims
                    .Where(x => x.TrimId == trimId && x.CarMakeId == makeId && x.CarModelId == modelId)
                    .FirstOrDefault();
                if(currentItem == null)
                {
                    _context.MakeModelTrims
                        .Add(new MakeModelTrim() { CarMakeId = makeId, CarModelId = modelId, TrimId = trimId });
                    _context.SaveChanges();
                }
            }
        }
    }
}
