using CarHub.Data.Models;
using System.Collections.Generic;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface ICarMakeRepository
    {
        void DeleteCarMake(int id);
        IEnumerable<CarMake> FindCarMakeBySearchPhrase(string searchPhrase);
        IEnumerable<CarMake> GetAllCarMakes();
        string GetCarMakeNameById(int id);
        int ManageCarMake(CarMake carMakeObj);
    }
}