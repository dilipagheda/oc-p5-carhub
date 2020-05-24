using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels
{
    public class InventoryViewModel
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        [DisplayName("Make")]
        public int CarMakeId { get; set; }

        public SelectList CarMakes { get; set; }

        public string CarMakeName { get; set; }

        public string NewCarMakeName { get; set; }

        [DisplayName("Model")]
        public int CarModelId { get; set; }

        public SelectList CarModels { get; set; }

        public string CarModelName { get; set; }

        public string NewCarModelName { get; set; }

        [DisplayName("Trim")]
        public int TrimId { get; set; }

        public SelectList Trims { get; set; }

        public string TrimName { get; set; }

        public string NewTrimName { get; set; }

        [DisplayName("Year")]
        public int Year { get; set; }


        [DisplayName("Body Type")]
        public int BodyTypeId { get; set; }

        public SelectList BodyTypes { get; set; }

        public string BodyTypeName { get; set; }

        public string NewBodyTypeName { get; set; }

        public int Kms { get; set; }

        public char TransmissionType { get; set; }

        public string RegoNumber { get; set; }

        public string RegoExpiryDate { get; set; }

        public string Description { get; set; }

        [DisplayName("Color")]
        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public string NewColorName { get; set; }

        public SelectList Colors { get; set; }

        public int NoOfSeats { get; set; }

        public int NoOfDoors { get; set; }

        public int NoOfCylinders { get; set; }

        [DisplayName("Drive Type")]
        public int DriveTypeId { get; set; }

        public string DriveTypeName { get; set; }

        public string NewDriveTypeName { get; set; }

        public SelectList DriveTypes { get; set; }

        [DisplayName("Fuel Type")]
        public int FuelTypeId { get; set; }

        public string FuelTypeName { get; set; }

        public string NewFuelTypeName { get; set; }

        public SelectList FuelTypes { get; set; }

        public string PurchaseDate { get; set; }

        public decimal PurchasePrice { get; set; }

        [DisplayName("Purchase Type")]
        public int PurchaseTypeId { get; set; }

        public string PurchaseTypeName { get; set; }

        public string NewPurchaseTypeName { get; set; }

        public SelectList PurchaseTypes { get; set; }

        public bool IsFeatured { get; set; }

        public string LotDate { get; set; }

        public string SaleDate { get; set; }

        public decimal SalePrice { get; set; }

        [DisplayName("Inventory Status")]
        public int InventoryStatusId { get; set; }

        public SelectList InventoryStatusList { get; set; }

        public string InventoryStatusName { get; set; }

        public string RepairDescription { get; set; }

        public decimal RepairCost { get; set; }

        public string TotalCost
        {
            get
            {
                var totalCost = this.PurchasePrice + this.RepairCost + 500;
                return "$" + totalCost.ToString("N2");
            }
        }

        public string TotalCostBeforeDiscount
        {
            get
            {
                var totalCost = this.PurchasePrice + this.RepairCost + 500;
                totalCost = totalCost + (totalCost * (decimal)0.10);
                return "$" + totalCost.ToString("N2");
            }
        }

        public string KmToDisplay { get { return this.Kms.ToString("N0"); } }

        public string TransmissionTypeToDisplay
        {
            get
            {
                if(this.TransmissionType == 'M')
                    return "Manual";
                else if(this.TransmissionType == 'A')
                    return "Automatic";
                else
                    return string.Empty;
            }
        }

        public List<string> AllImages { get; set; }
    }
}
