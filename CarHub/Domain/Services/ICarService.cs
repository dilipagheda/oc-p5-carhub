﻿using CarHub.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.Services
{
    public interface ICarService
    {
        public List<CarMakeViewModel> GetAllCarMakes();

    }
}