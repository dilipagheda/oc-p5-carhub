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
                .ForMember(dest => dest.RegoExpiryDate, opt => opt.MapFrom(src => String.Format("{0:dd/MM/yyyy}", src.RegoExpiry)))
                .ReverseMap()
                .ForPath(dest => dest.RegoExpiry, opt => opt.MapFrom(src => DateTime.Parse(src.RegoExpiryDate)));


            CreateMap<Inventory, InventoryViewModel>()
                .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => String.Format("{0:dd/MM/yyyy}", src.PurchaseDate)))
                .ForMember(dest => dest.LotDate, opt => opt.MapFrom(src => String.Format("{0:dd/MM/yyyy}", src.LotDate)))
                .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => String.Format("{0:dd/MM/yyyy}", src.SaleDate)))
                .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.SalePrice))
                .ForMember(dest => dest.InventoryStatusId, opt => opt.MapFrom(src => src.InventoryStatusId))
                .ReverseMap()
                .ForPath(dest => dest.LotDate, opt => opt.MapFrom(src => DateTime.Parse(src.LotDate)))
                .ForPath(dest => dest.SaleDate, opt => opt.MapFrom(src => DateTime.Parse(src.SaleDate)))
                .ForPath(dest => dest.CarId, opt => opt.MapFrom(src => src.Id));


            CreateMap<Repair, InventoryViewModel>()
                .ForMember(dest => dest.RepairDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.RepairCost, opt => opt.MapFrom(src => src.Cost));


            CreateMap<InventoryViewModel, Repair>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.RepairDescription))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.RepairCost))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Car, opt => opt.Ignore());

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
                .ForMember(dest => dest.DriveTypes, opt => opt.MapFrom(src => new SelectList(src, "Id", "DriveTypeName")));

            CreateMap<List<PurchaseType>, InventoryViewModel>()
                .ForMember(dest => dest.PurchaseTypes, opt => opt.MapFrom(src => new SelectList(src, "Id", "PurchaseTypeName")));

            CreateMap<List<Color>, InventoryViewModel>()
                .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => new SelectList(src, "Id", "ColorName")));

            CreateMap<List<InventoryStatus>, InventoryViewModel>()
                .ForMember(dest => dest.InventoryStatusList, opt => opt.MapFrom(src => new SelectList(src, "Id", "Status")));


        }
    }
}
