using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels.Admin
{
    public class AddNewCarViewModel
    {
        [DisplayName("Make")]
        public int CarMakeId { get; set; }
        public SelectList CarMakes { get; set; }
        public string NewCarMake { get; set; }

        [DisplayName("Model")]
        public int CarModelId { get; set; }
        public SelectList CarModels { get; set; }
        public string NewCarModel { get; set; }

        [DisplayName("Trim")]
        public int TrimId { get; set; }
        public SelectList Trims { get; set; }
        public string NewTrim { get; set; }

        [DisplayName("Year")]
        public int Year { get; set; }
        public int NewYear { get; set; }

        [DisplayName("Body Type")]
        public int BodyTypeId { get; set; }
        public SelectList BodyTypes { get; set; }
        public string NewBodyType { get; set; }

        public int Kms { get; set; }
        public char TransmissionType { get; set; }
        public string RegoNumber { get; set; }
        public string RegoExpiryDate { get; set; }
        public string Description { get; set; }
        [DisplayName("Color")]
        public int ColorId { get; set; }
        public string NewColor { get; set; }
        public SelectList Colors { get; set; }

        public int NoOfSeats { get; set; }
        public int NoOfDoors { get; set; }
        public int NoOfCylinders { get; set; }

        [DisplayName("Drive Type")]
        public int DriveTypeId { get; set; }
        public string NewDriveType { get; set; }
        public SelectList DriveTypes { get; set; }

        [DisplayName("Fuel Type")]
        public int FuelTypeId { get; set; }
        public string NewFuelType { get; set; }
        public SelectList FuelTypes { get; set; }

        public string PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }

        [DisplayName("Purchase Type")]
        public int PurchaseTypeId { get; set; }
        public string NewPurchaseType { get; set; }
        public SelectList PurchaseTypes { get; set; }

        public bool IsFeatured { get; set; }
        public string LotDate { get; set; }
    }
}
