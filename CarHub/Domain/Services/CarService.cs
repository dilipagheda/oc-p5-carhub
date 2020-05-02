using AutoMapper;
using CarHub.Data.Repositories;
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

        public CarService(IMapper mapper, ICarMakeRepository carMakeRepository)
        {
            _mapper = mapper;
            _carMakeRepository = carMakeRepository;
        }

        public List<CarMakeViewModel> GetAllCarMakes()
        {
            var carMakes = _carMakeRepository.GetAllCarMakes();
            var carMakeViewModels = _mapper.Map<List<CarMakeViewModel>>(carMakes);
            return carMakeViewModels;
        }
    }
}
