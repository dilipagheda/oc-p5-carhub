using CarHub.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.Services.Interfaces
{
    public interface ICarService
    {
        public List<CarMakeViewModel> GetAllCarMakes();
        public List<CarModelViewModel> GetAllCarModelsByMake(int makeId);

        public List<TrimViewModel> GetAllTrimsByModel(int modelId);
        public List<BodyTypeViewModel> GetAllBodyTypes();
        public List<FuelTypeViewModel> GetAllFuelTypes();
        public List<DriveTypeViewModel> GetAllDriveTypes();
        public List<PurchaseTypeViewModel> GetAllPurchaseTypes();

    }
}
