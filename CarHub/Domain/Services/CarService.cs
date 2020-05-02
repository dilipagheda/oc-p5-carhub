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

        public CarService(IMapper mapper, ICarMakeRepository carMakeRepository, ICarModelRepository carModelRepository, ITrimRepository trimRepository)
        {
            _mapper = mapper;
            _carMakeRepository = carMakeRepository;
            _carModelRepository = carModelRepository;
            _trimRepository = trimRepository;
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
    }
}
