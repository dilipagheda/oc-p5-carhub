using AutoMapper;
using CarHub.Data.Models;
using CarHub.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.Profiles
{
    public class CarHubProfile : Profile
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
            CreateMap<Color, ColorViewModel>();

            CreateMap<Car, InventoryViewModel>()
                .ForMember(dest => dest.RegoExpiryDate,
                           opt => opt.MapFrom(src => String.Format("{0:dd/MM/yyyy}", src.RegoExpiry)))
                .ForMember(dest => dest.CarMakeName, opt => opt.MapFrom(src => src.CarMake.MakeName))
                .ForMember(dest => dest.CarModelName, opt => opt.MapFrom(src => src.CarModel.ModelName))
                .ForMember(dest => dest.BodyTypeName, opt => opt.MapFrom(src => src.BodyType.BodyTypeName))
                .ForMember(dest => dest.FuelTypeName, opt => opt.MapFrom(src => src.FuelType.FuelTypeName))
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.ColorName))
                .ForMember(dest => dest.TrimName, opt => opt.MapFrom(src => src.Trim.TrimName))
                .ForMember(dest => dest.DriveTypeName, opt => opt.MapFrom(src => src.DriveType.DriveTypeName))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForPath(dest => dest.RegoExpiry, opt => opt.MapFrom(src => DateTime.Parse(src.RegoExpiryDate)))
                .ForPath(dest => dest.Id, opt => opt.Ignore())
                .ForPath(dest => dest.CarMake, opt => opt.Ignore())
                .ForPath(dest => dest.CarModel, opt => opt.Ignore())
                .ForPath(dest => dest.BodyType, opt => opt.Ignore())
                .ForPath(dest => dest.FuelType, opt => opt.Ignore())
                .ForPath(dest => dest.Color, opt => opt.Ignore())
                .ForPath(dest => dest.Trim, opt => opt.Ignore())
                .ForPath(dest => dest.DriveType, opt => opt.Ignore());

            CreateMap<Inventory, InventoryViewModel>()
                .ForMember(dest => dest.PurchaseDate,
                           opt => opt.MapFrom(src => String.Format("{0:dd/MM/yyyy}", src.PurchaseDate)))
                .ForMember(dest => dest.LotDate,
                           opt => opt.MapFrom(src => String.Format("{0:dd/MM/yyyy}", src.LotDate)))
                .ForMember(dest => dest.SaleDate,
                           opt => opt.MapFrom(src => String.Format("{0:dd/MM/yyyy}", src.SaleDate)))
                .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.SalePrice))
                .ForMember(dest => dest.InventoryStatusId, opt => opt.MapFrom(src => src.InventoryStatusId))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                .ReverseMap()
                .ForPath(dest => dest.LotDate, opt => opt.MapFrom(src => DateTime.Parse(src.LotDate)))
                .ForPath(dest => dest.SaleDate, opt => opt.MapFrom(src => DateTime.Parse(src.SaleDate)))
                .ForPath(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId));


            CreateMap<Repair, InventoryViewModel>()
                .ForMember(dest => dest.RepairDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.RepairCost, opt => opt.MapFrom(src => src.Cost))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                .ForMember(dest => dest.Description, opt => opt.Ignore());

            CreateMap<InventoryViewModel, Repair>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.RepairDescription))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.RepairCost))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                .ForMember(dest => dest.Car, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            //mappings for displaying value in dropdowns. It needs to be one-way only.

            CreateMap<List<CarMake>, InventoryViewModel>()
                .ForMember(dest => dest.CarMakes, opt => opt.MapFrom(src => new SelectList(src, "Id", "MakeName")));

            CreateMap<List<CarModel>, InventoryViewModel>()
                .ForMember(dest => dest.CarModels, opt => opt.MapFrom(src => new SelectList(src, "Id", "ModelName")));

            CreateMap<List<Trim>, InventoryViewModel>()
                .ForMember(dest => dest.Trims, opt => opt.MapFrom(src => new SelectList(src, "Id", "TrimName")));

            CreateMap<List<CarMake>, InventoryViewModel>()
                .ForMember(dest => dest.CarMakes, opt => opt.MapFrom(src => new SelectList(src, "Id", "MakeName")));

            CreateMap<List<BodyType>, InventoryViewModel>()
                .ForMember(dest => dest.BodyTypes, opt => opt.MapFrom(src => new SelectList(src, "Id", "BodyTypeName")));

            CreateMap<List<FuelType>, InventoryViewModel>()
                .ForMember(dest => dest.FuelTypes, opt => opt.MapFrom(src => new SelectList(src, "Id", "FuelTypeName")));

            CreateMap<List<DriveType>, InventoryViewModel>()
                .ForMember(dest => dest.DriveTypes,
                           opt => opt.MapFrom(src => new SelectList(src, "Id", "DriveTypeName")));

            CreateMap<List<PurchaseType>, InventoryViewModel>()
                .ForMember(dest => dest.PurchaseTypes,
                           opt => opt.MapFrom(src => new SelectList(src, "Id", "PurchaseTypeName")));

            CreateMap<List<Color>, InventoryViewModel>()
                .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => new SelectList(src, "Id", "ColorName")));

            CreateMap<List<InventoryStatus>, InventoryViewModel>()
                .ForMember(dest => dest.InventoryStatusList,
                           opt => opt.MapFrom(src => new SelectList(src, "Id", "Status")));

            CreateMap<Car, Car>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForPath(dest => dest.CarMake, opt => opt.Ignore())
                .ForPath(dest => dest.CarModel, opt => opt.Ignore())
                .ForPath(dest => dest.BodyType, opt => opt.Ignore())
                .ForPath(dest => dest.FuelType, opt => opt.Ignore())
                .ForPath(dest => dest.Color, opt => opt.Ignore())
                .ForPath(dest => dest.Trim, opt => opt.Ignore())
                .ForPath(dest => dest.DriveType, opt => opt.Ignore());

            CreateMap<Inventory, Inventory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CarId, opt => opt.Ignore())
                .ForMember(dest => dest.PurchaseType, opt => opt.Ignore())
                .ForMember(dest => dest.InventoryStatus, opt => opt.Ignore());


            CreateMap<Repair, Repair>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CarId, opt => opt.Ignore());

            CreateMap<InventoryViewModel, InventoryItemSummary>()
                .ForMember(dest => dest.InventoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TotalCost))
                .ForMember(dest => dest.HeadLine,
                           opt => opt.MapFrom(src => $"{src.CarMakeName} {src.CarModelName} {src.TrimName}"))
                .ForMember(dest => dest.Image,
                           opt => opt.MapFrom(src => src.AllImages != null ? src.AllImages[0] : null));
        }
    }
}
