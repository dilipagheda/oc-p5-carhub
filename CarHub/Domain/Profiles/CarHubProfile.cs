using AutoMapper;
using CarHub.Data.Models;
using CarHub.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.Profiles
{
    public class CarHubProfile:Profile
    {
        public CarHubProfile()
        {
            CreateMap<CarMake, CarMakeViewModel>()
                .ForMember(dest => dest.CarMakeName, opt => opt.MapFrom(src => src.MakeName));

            CreateMap<CarModel, CarModelViewModel>()
                .ForMember(dest => dest.CarModelName, opt => opt.MapFrom(src => src.ModelName));

            CreateMap<Trim, TrimViewModel>();

            CreateMap<BodyType, BodyTypeViewModel>();

            CreateMap<FuelType, FuelTypeViewModel>();
            CreateMap<DriveType, DriveTypeViewModel>();
            CreateMap<PurchaseType, PurchaseTypeViewModel>();
        }
    }
}
