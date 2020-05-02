using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface ICarMakeRepository
    {
        public IEnumerable<CarMake> GetAllCarMakes();

        public void AddNewCarMake(CarMake carMakeObj);

        public void UpdateCarMake(int id, string carMakeName);
        public void DeleteCarMake(int id);

        public IEnumerable<CarMake> FindCarMakeBySearchPhrase(string searchPhrase);
    }
}
