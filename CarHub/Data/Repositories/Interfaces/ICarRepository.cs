using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public List<Car> GetAllCars();

        public Guid? AddNewCar(Car carObj);

        public Car GetCarById(string id);

        public void DeleteCarById(string id);

        public void EditCar(string carId, Car carObj);

        public void AddMakeModelTrim(int makeId, int modelId, int trimId);
    }
}
