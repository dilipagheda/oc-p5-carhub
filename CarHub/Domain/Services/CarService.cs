using AutoMapper;
using CarHub.Data.Repositories.Interfaces;
using CarHub.Domain.Services.Interfaces;
using CarHub.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarMakeRepository _carMakeRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly ITrimRepository _trimRepository;
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly IDriveTypeRepository _driveTypeRepository;
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly IPurchaseTypeRepository _purchaseTypeRepository;

        public CarService(IMapper mapper, 
                          ICarMakeRepository carMakeRepository, 
                          ICarModelRepository carModelRepository, 
                          ITrimRepository trimRepository,
                          IBodyTypeRepository bodyTypeRepository,
                          IDriveTypeRepository driveTypeRepository,
                          IFuelTypeRepository fuelTypeRepository,
                          IPurchaseTypeRepository purchaseTypeRepository)
        {
            _mapper = mapper;
            _carMakeRepository = carMakeRepository;
            _carModelRepository = carModelRepository;
            _trimRepository = trimRepository;
            _bodyTypeRepository = bodyTypeRepository;
            _driveTypeRepository = driveTypeRepository;
            _fuelTypeRepository = fuelTypeRepository;
            _purchaseTypeRepository = purchaseTypeRepository;
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
    }
}
