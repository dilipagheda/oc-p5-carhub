using CarHub.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.Services.Interfaces
{
    public interface IInventoryService
    {
        public List<CarMakeViewModel> GetAllCarMakes();
        public List<CarModelViewModel> GetAllCarModelsByMake(int makeId);

        public List<TrimViewModel> GetAllTrimsByModel(int modelId);
        public List<BodyTypeViewModel> GetAllBodyTypes();
        public List<FuelTypeViewModel> GetAllFuelTypes();
        public List<DriveTypeViewModel> GetAllDriveTypes();
        public List<PurchaseTypeViewModel> GetAllPurchaseTypes();

        public List<ColorViewModel> GetAllColors();
        public InventoryViewModel GetInventoryById(string id);
        public Guid? AddNewInventory(InventoryViewModel inventoryViewModel);
        public Task AddNewMediaToInventoryAsync(FileData fileData);

        public List<InventoryViewModel> GetAllInventoryItems();

        public void DeleteInventoryById(string inventoryId);
    }
}
