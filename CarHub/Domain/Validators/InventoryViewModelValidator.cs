using CarHub.Domain.ViewModels;
using FluentValidation;
using System;
using System.Linq;

namespace CarHub.Domain.Validators
{
    public class InventoryViewModelValidator : AbstractValidator<InventoryViewModel>
    {
        public InventoryViewModelValidator()
        {
            RuleFor(x => x.CarMakeId).NotNull();
            RuleFor(x => x.CarMakeId).GreaterThan(0).When(x => x.NewCarMakeName == null);
            RuleFor(x => x.NewCarMakeName).NotNull().When(x => x.CarMakeId <= 0);

            RuleFor(x => x.CarModelId).NotNull();
            RuleFor(x => x.CarModelId).GreaterThan(0).When(x => x.NewCarModelName == null);
            RuleFor(x => x.NewCarModelName).NotNull().When(x => x.CarModelId <= 0);

            RuleFor(x => x.TrimId).NotNull();
            RuleFor(x => x.TrimId).GreaterThan(0).When(x => x.NewTrimName == null);
            RuleFor(x => x.NewTrimName).NotNull().When(x => x.TrimId <= 0);

            var currentYear = DateTime.Now.Year;
            RuleFor(x => x.Year).GreaterThanOrEqualTo(currentYear - 20);
            RuleFor(x => x.Year).LessThanOrEqualTo(currentYear + 1);

            RuleFor(x => x.BodyTypeId).NotNull();
            RuleFor(x => x.BodyTypeId).GreaterThan(0).When(x => x.NewBodyTypeName == null);
            RuleFor(x => x.NewBodyTypeName).NotNull().When(x => x.BodyTypeId <= 0);

            RuleFor(x => x.Kms).GreaterThan(0);
            RuleFor(x => x.Kms).LessThanOrEqualTo(500000);

            RuleFor(x => x.TransmissionType).Equals('M');
            RuleFor(x => x.TransmissionType).Equals('A');

            RuleFor(x => x.RegoNumber).NotNull();
            RuleFor(x => x.RegoNumber).Length(1, 10);

            RuleFor(x => x.RegoExpiryDate).NotNull();
            RuleFor(x => Convert.ToDateTime(x.RegoExpiryDate)).NotNull();
            RuleFor(x => Convert.ToDateTime(x.RegoExpiryDate).Date)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Rego expiry date must be greater than or equal to today");

            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Description).MinimumLength(1);
            RuleFor(x => x.Description).MaximumLength(1000);

            RuleFor(x => x.ColorId).NotNull();
            RuleFor(x => x.ColorId).GreaterThan(0).When(x => x.NewColorName == null);
            RuleFor(x => x.NewColorName).NotNull().When(x => x.ColorId <= 0);

            RuleFor(x => x.NoOfSeats).InclusiveBetween(1, 10);
            RuleFor(x => x.NoOfDoors).InclusiveBetween(1, 10);
            RuleFor(x => x.NoOfCylinders).InclusiveBetween(1, 10);

            RuleFor(x => x.DriveTypeId).NotNull();
            RuleFor(x => x.DriveTypeId).GreaterThan(0).When(x => x.NewDriveTypeName == null);
            RuleFor(x => x.NewDriveTypeName).NotNull().When(x => x.DriveTypeId <= 0);


            RuleFor(x => x.FuelTypeId).NotNull();
            RuleFor(x => x.FuelTypeId).GreaterThan(0).When(x => x.NewFuelTypeName == null);
            RuleFor(x => x.NewFuelTypeName).NotNull().When(x => x.FuelTypeId <= 0);

            RuleFor(x => x.PurchaseDate).NotNull();
            RuleFor(x => Convert.ToDateTime(x.PurchaseDate)).NotNull();
            RuleFor(x => Convert.ToDateTime(x.PurchaseDate).Date)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Purchase date must be greater than or equal to today");


            RuleFor(x => x.PurchasePrice).NotNull();
            RuleFor(x => x.PurchasePrice).GreaterThan(0);

            RuleFor(x => x.SalePrice)
                .NotNull()
                .When(x => x.InventoryStatusId == 3)
                .WithMessage("Sale price is required when inventory status is Sold");

            RuleFor(x => x.SaleDate)
                .NotNull()
                .When(x => x.InventoryStatusId == 3)
                .WithMessage("Sale date is required when inventory status is Sold");

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(x => x.PurchasePrice + x.RepairCost + 500)
                .When(x => x.InventoryStatusId == 3)
                .WithMessage("Sale price should be greater than or equal to sum of  purchase price, repair cost and profit of $500");

            RuleFor(x => x.PurchaseTypeId).NotNull();
            RuleFor(x => x.PurchaseTypeId).GreaterThan(0).When(x => x.NewPurchaseTypeName == null);
            RuleFor(x => x.NewPurchaseTypeName).NotNull().When(x => x.PurchaseTypeId <= 0);

            RuleFor(x => x.IsFeatured).NotNull();

            RuleFor(x => x.LotDate).NotNull();
            RuleFor(x => Convert.ToDateTime(x.LotDate)).NotNull();
            RuleFor(x => Convert.ToDateTime(x.LotDate).Date)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Lot date must be greater than or equal to today");
        }
    }
}
