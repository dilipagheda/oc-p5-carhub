using CarHub.Domain.ViewModels.Admin;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.Validators
{
    public class AddNewCarViewModelValidator : AbstractValidator<AddNewCarViewModel>
    {
        public AddNewCarViewModelValidator()
        {
            RuleFor(x => x.CarMakeId).NotNull();
        }
    }
}
