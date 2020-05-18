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
    public class RepairProfile : Profile
    {
        public RepairProfile()
        {

            CreateMap<Repair, InventoryViewModel>()
                .ForMember(dest => dest.RepairDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.RepairCost, opt => opt.MapFrom(src => src.Cost))
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<InventoryViewModel, Repair>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.RepairDescription))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.RepairCost))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Car, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
