﻿using AutoMapper;
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
        }
    }
}