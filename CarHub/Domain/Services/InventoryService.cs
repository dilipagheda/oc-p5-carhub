using AutoMapper;
using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using CarHub.Domain.Services.Interfaces;
using CarHub.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly ICarMakeRepository _carMakeRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly ITrimRepository _trimRepository;
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly IDriveTypeRepository _driveTypeRepository;
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly IPurchaseTypeRepository _purchaseTypeRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ICarRepository _carRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IInventoryStatusRepository _inventoryStatusRepository;
        private readonly IRepairRepository _repairRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IWebHostEnvironment _appEnvironment;

        public InventoryService(IMapper mapper,
                                ICarMakeRepository carMakeRepository,
                                ICarModelRepository carModelRepository,
                                ITrimRepository trimRepository,
                                IBodyTypeRepository bodyTypeRepository,
                                IDriveTypeRepository driveTypeRepository,
                                IFuelTypeRepository fuelTypeRepository,
                                IPurchaseTypeRepository purchaseTypeRepository,
                                IColorRepository colorRepository,
                                ICarRepository carRepository,
                                IInventoryRepository inventoryRepository,
                                IInventoryStatusRepository inventoryStatusRepository,
                                IRepairRepository repairRepository,
                                IMediaRepository mediaRepository,
                                IWebHostEnvironment appEnvironment)
        {
            _mapper = mapper;
            _carMakeRepository = carMakeRepository;
            _carModelRepository = carModelRepository;
            _trimRepository = trimRepository;
            _bodyTypeRepository = bodyTypeRepository;
            _driveTypeRepository = driveTypeRepository;
            _fuelTypeRepository = fuelTypeRepository;
            _purchaseTypeRepository = purchaseTypeRepository;
            _colorRepository = colorRepository;
            _carRepository = carRepository;
            _inventoryRepository = inventoryRepository;
            _inventoryStatusRepository = inventoryStatusRepository;
            _repairRepository = repairRepository;
            _mediaRepository = mediaRepository;
            _appEnvironment = appEnvironment;
        }

        public List<CarMakeViewModel> GetAllCarMakes()
        {
            var carMakes = _carMakeRepository.GetAllCarMakes();
            var carMakeViewModels = _mapper.Map<List<CarMakeViewModel>>(carMakes);
            return carMakeViewModels;
        }

        public List<CarModelViewModel> GetAllCarModelsByMake(int makeId)
        {
            var carModels = _carModelRepository.GetAllModelsByMake(makeId);
            var carModelsViewModel = _mapper.Map<List<CarModelViewModel>>(carModels);
            return carModelsViewModel;
        }

        public List<TrimViewModel> GetAllTrimsByModel(int modelId)
        {
            var trims = _trimRepository.GetAllTrimsByModel(modelId);
            var trimsViewModel = _mapper.Map<List<TrimViewModel>>(trims);
            return trimsViewModel;
        }

        public List<BodyTypeViewModel> GetAllBodyTypes()
        {
            var bodyTypes = _bodyTypeRepository.GetAllBodyTypes();
            var bodyTypesViewModel = _mapper.Map<List<BodyTypeViewModel>>(bodyTypes);
            return bodyTypesViewModel;
        }

        public List<DriveTypeViewModel> GetAllDriveTypes()
        {
            var driveTypes = _driveTypeRepository.GetAllDriveTypes();
            var driveTypesViewModel = _mapper.Map<List<DriveTypeViewModel>>(driveTypes);
            return driveTypesViewModel;
        }

        public List<FuelTypeViewModel> GetAllFuelTypes()
        {
            var fuelTypes = _fuelTypeRepository.GetAllFuelTypes();
            var fuelTypesViewModel = _mapper.Map<List<FuelTypeViewModel>>(fuelTypes);
            return fuelTypesViewModel;
        }

        public List<PurchaseTypeViewModel> GetAllPurchaseTypes()
        {
            var purchaseTypes = _purchaseTypeRepository.GetAllPurchaseTypes();
            var purchaseTypesViewModel = _mapper.Map<List<PurchaseTypeViewModel>>(purchaseTypes);
            return purchaseTypesViewModel;
        }

        public List<ColorViewModel> GetAllColors()
        {
            var colors = _colorRepository.GetAllColors();
            var colorsViewModel = _mapper.Map<List<ColorViewModel>>(colors);
            return colorsViewModel;
        }

        public Guid? AddNewInventory(InventoryViewModel inventoryViewModel)
        {
            var car = _mapper.Map<Car>(inventoryViewModel);

            if(inventoryViewModel.CarMakeName != null)
            {
                var carMakeId = _carMakeRepository.ManageCarMake(new CarMake()
                    { MakeName = inventoryViewModel.CarMakeName });
                car.CarMakeId = carMakeId;
            }

            if(inventoryViewModel.CarModelName != null)
            {
                var carModelId = _carModelRepository.ManageCarModel(new CarModel()
                    { ModelName = inventoryViewModel.CarModelName });
                car.CarModelId = carModelId;
            }

            if(inventoryViewModel.TrimName != null)
            {
                var trimId = _trimRepository.ManageTrim(new Trim() { TrimName = inventoryViewModel.TrimName });
                car.TrimId = trimId;
            }

            _carRepository.AddMakeModelTrim(car.CarMakeId, car.CarModelId, car.TrimId);

            if(inventoryViewModel.BodyTypeName != null)
            {
                var bodyTypeId = _bodyTypeRepository.ManageBodyType(new BodyType()
                    { BodyTypeName = inventoryViewModel.BodyTypeName });
                car.BodyTypeId = bodyTypeId;
            }
            if(inventoryViewModel.ColorName != null)
            {
                var colorId = _colorRepository.ManageColor(new Color() { ColorName = inventoryViewModel.ColorName });
                car.ColorId = colorId;
            }
            if(inventoryViewModel.DriveTypeName != null)
            {
                var driveTypeId = _driveTypeRepository.ManageDriveType(new Data.Models.DriveType()
                    { DriveTypeName = inventoryViewModel.DriveTypeName });
                car.DriveTypeId = driveTypeId;
            }
            if(inventoryViewModel.FuelTypeName != null)
            {
                var fuelTypeId = _fuelTypeRepository.ManageFuelType(new Data.Models.FuelType()
                    { FuelTypeName = inventoryViewModel.FuelTypeName });
                car.FuelTypeId = fuelTypeId;
            }


            Guid? newCarId = _carRepository.AddNewCar(car);

            if(newCarId == null)
            {
                return null;
            }

            inventoryViewModel.Id = (Guid)newCarId;

            var inventory = _mapper.Map<Inventory>(inventoryViewModel);

            Guid? newInventoryId = _inventoryRepository.AddInventory(inventory);

            var repairDetails = _mapper.Map<Repair>(inventoryViewModel);

            _repairRepository.AddNewRepair(repairDetails);

            return newCarId;
        }

        public bool EditInventory(InventoryViewModel inventoryViewModel)
        {
            var car = _mapper.Map<Car>(inventoryViewModel);

            var inventory = _inventoryRepository.GetInventoryDetailsById(inventoryViewModel.Id.ToString());

            if(inventory == null)
                return false;

            if(inventory.CarId == null || inventory.CarId == Guid.Empty)
                return false;


            if(inventoryViewModel.CarMakeName != null)
            {
                var carMakeId = _carMakeRepository.ManageCarMake(new CarMake()
                    { MakeName = inventoryViewModel.CarMakeName });
                car.CarMakeId = carMakeId;
            }

            if(inventoryViewModel.CarModelName != null)
            {
                var carModelId = _carModelRepository.ManageCarModel(new CarModel()
                    { ModelName = inventoryViewModel.CarModelName });
                car.CarModelId = carModelId;
            }

            if(inventoryViewModel.TrimName != null)
            {
                var trimId = _trimRepository.ManageTrim(new Trim() { TrimName = inventoryViewModel.TrimName });
                car.TrimId = trimId;
            }

            _carRepository.AddMakeModelTrim(car.CarMakeId, car.CarModelId, car.TrimId);

            if(inventoryViewModel.BodyTypeName != null)
            {
                var bodyTypeId = _bodyTypeRepository.ManageBodyType(new BodyType()
                    { BodyTypeName = inventoryViewModel.BodyTypeName });
                car.BodyTypeId = bodyTypeId;
            }
            if(inventoryViewModel.ColorName != null)
            {
                var colorId = _colorRepository.ManageColor(new Color() { ColorName = inventoryViewModel.ColorName });
                car.ColorId = colorId;
            }
            if(inventoryViewModel.DriveTypeName != null)
            {
                var driveTypeId = _driveTypeRepository.ManageDriveType(new Data.Models.DriveType()
                    { DriveTypeName = inventoryViewModel.DriveTypeName });
                car.DriveTypeId = driveTypeId;
            }
            if(inventoryViewModel.FuelTypeName != null)
            {
                var fuelTypeId = _fuelTypeRepository.ManageFuelType(new Data.Models.FuelType()
                    { FuelTypeName = inventoryViewModel.FuelTypeName });
                car.FuelTypeId = fuelTypeId;
            }


            string carId = inventory.CarId.ToString();

            _carRepository.EditCar(carId, car);

            var updatedInventory = _mapper.Map<Inventory>(inventoryViewModel);

            _inventoryRepository.EditInventory(updatedInventory);

            var repairDetails = _mapper.Map<Repair>(inventoryViewModel);

            _repairRepository.EditRepair(carId, repairDetails);

            return true;
        }

        public InventoryViewModel GetInventoryById(string id)
        {
            if(id == null)
            {
                var carMakes = _carMakeRepository.GetAllCarMakes();
                var bodyTypes = _bodyTypeRepository.GetAllBodyTypes();
                var fuelTypes = _fuelTypeRepository.GetAllFuelTypes();
                var driveTypes = _driveTypeRepository.GetAllDriveTypes();
                var purchaseTypes = _purchaseTypeRepository.GetAllPurchaseTypes();
                var colors = _colorRepository.GetAllColors();
                var inventoryStatusList = _inventoryStatusRepository.GetAllInventoryStatus();

                var inventoryViewModel = _mapper.Map<InventoryViewModel>(carMakes);
                inventoryViewModel = _mapper.Map(bodyTypes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(fuelTypes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(driveTypes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(purchaseTypes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(colors, inventoryViewModel);
                inventoryViewModel = _mapper.Map(inventoryStatusList, inventoryViewModel);
                return inventoryViewModel;
            } else
            {
                var inventory = _inventoryRepository.GetInventoryDetailsById(id);
                string carId = inventory.CarId.ToString();

                //find car for this inventory
                var car = inventory.Car;

                //find repair details for this inventory
                var repairs = _repairRepository.GetRepairDetailsByCarId(carId);

                //mappings
                var inventoryViewModel = _mapper.Map<InventoryViewModel>(inventory);
                inventoryViewModel = _mapper.Map(car, inventoryViewModel);

                if(repairs != null)
                {
                    inventoryViewModel = _mapper.Map(repairs, inventoryViewModel);
                }

                //map all dropdown data
                var carMakes = _carMakeRepository.GetAllCarMakes();
                var carModelsbyMake = _carModelRepository.GetAllModelsByMake(car.CarMakeId);
                var carTrimsByModel = _trimRepository.GetAllTrimsByModel(car.CarModelId);
                var bodyTypes = _bodyTypeRepository.GetAllBodyTypes();
                var fuelTypes = _fuelTypeRepository.GetAllFuelTypes();
                var driveTypes = _driveTypeRepository.GetAllDriveTypes();
                var purchaseTypes = _purchaseTypeRepository.GetAllPurchaseTypes();
                var colors = _colorRepository.GetAllColors();
                var inventoryStatusList = _inventoryStatusRepository.GetAllInventoryStatus();

                inventoryViewModel = _mapper.Map(carMakes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(carModelsbyMake, inventoryViewModel);
                inventoryViewModel = _mapper.Map(carTrimsByModel, inventoryViewModel);
                inventoryViewModel = _mapper.Map(bodyTypes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(fuelTypes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(driveTypes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(purchaseTypes, inventoryViewModel);
                inventoryViewModel = _mapper.Map(colors, inventoryViewModel);
                inventoryViewModel = _mapper.Map(inventoryStatusList, inventoryViewModel);

                inventoryViewModel.AllImages = _mediaRepository.GetAllMediaFileNamesByInventoryId(id);
                return inventoryViewModel;
            }
        }

        public async Task AddNewMediaToInventoryAsync(FileData fileData)
        {
            RemoveExistingFiles(fileData.InventoryId);
            var uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\img");
            var file = fileData.File;
            var contentType = file.ContentType;
            var inventoryId = fileData.InventoryId;
            string fileName = null;

            if(file.Length > 0)
            {
                fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + Path.GetExtension(file.FileName);

                using(var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            var mediaObj = new Media() { ContentType = contentType, FileName = fileName, Caption = string.Empty };

            _mediaRepository.AddNewMediaToInventory(inventoryId, false, mediaObj);
        }

        private void RemoveExistingFiles(string inventoryId)
        {
            var files = _mediaRepository.DeleteMediaFromInventory(inventoryId);
            foreach(var file in files)
            {
                var uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\img");
                File.Delete(Path.Combine(uploads, file));
            }
        }

        public List<InventoryViewModel> GetAllInventoryItems()
        {
            var inventoryItems = _inventoryRepository.GetAllInventoryItems();
            var inventoryViewModelItems = new List<InventoryViewModel>();

            inventoryItems.ForEach(inventoryItem =>
            {
                string carId = inventoryItem.CarId.ToString();

                //find car for this inventory
                var car = inventoryItem.Car;

                //find repair details for this inventory
                var repairs = _repairRepository.GetRepairDetailsByCarId(carId);

                //mappings
                var inventoryViewModel = _mapper.Map<InventoryViewModel>(inventoryItem);
                inventoryViewModel = _mapper.Map(car, inventoryViewModel);

                if(repairs != null)
                {
                    inventoryViewModel = _mapper.Map(repairs, inventoryViewModel);
                }

                inventoryViewModel.CarMakeName = _carMakeRepository.GetCarMakeNameById(car.CarMakeId);
                inventoryViewModel.CarModelName = _carModelRepository.GetCarModelNameById(car.CarModelId);

                inventoryViewModel.TrimName = _trimRepository.GetTrimById(car.TrimId);

                inventoryViewModel.BodyTypeName = _bodyTypeRepository.GetBodyTypeById(car.BodyTypeId);

                inventoryViewModel.FuelTypeName = _fuelTypeRepository.GetFuelTypeById(car.FuelTypeId);

                inventoryViewModel.DriveTypeName = _driveTypeRepository.GetDriveTypeById(car.DriveTypeId);

                inventoryViewModel.PurchaseTypeName = _purchaseTypeRepository.GetPurchaseTypeById(inventoryItem.PurchaseTypeId);

                inventoryViewModel.ColorName = _colorRepository.GetColorById(car.ColorId);
                inventoryViewModel.InventoryStatusName = _inventoryStatusRepository.GetInventoryStatusById(inventoryItem.InventoryStatusId);
                inventoryViewModel.AllImages = _mediaRepository.GetAllMediaFileNamesByInventoryId(inventoryItem.Id
                    .ToString());
                inventoryViewModelItems.Add(inventoryViewModel);
            });

            return inventoryViewModelItems;
        }


        public void DeleteInventoryById(string inventoryId)
        {
            var carId = _inventoryRepository.GetInventoryDetailsById(inventoryId).CarId;

            _inventoryRepository.DeleteInventoryById(inventoryId);
            _carRepository.DeleteCarById(carId.ToString());
            _repairRepository.DeleteRepairDetailsByCarId(carId.ToString());
            _mediaRepository.DeleteMediaFromInventory(inventoryId);
        }
    }
}
