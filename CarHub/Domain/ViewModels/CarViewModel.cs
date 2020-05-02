using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Domain.ViewModels
{
    public class CarViewModel
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string Trim { get; set; }
        public int Kms { get; set; }
        public string TransmissionType { get; set; }
        public string RegoNumber { get; set; }
        public DateTime RegoExpiry { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public string BodyType { get; set; }
        public int NoOfSeats { get; set; }
        public int NoOfDoors { get; set; }
        public int NoOfCylinders { get; set; }
        public string DriveType { get; set; }

        public string FuelType { get; set; }
    }
}
