using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public CarMake CarMake { get; set; }
        public CarModel CarModel { get; set; }
        public Trim Trim { get; set; }
        public int Kms { get; set; }
        public char TransmissionType { get; set; }
        public string RegoNumber { get; set; }
        public DateTime RegoExpiry { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }

        public BodyType BodyType { get; set; }
        public int NoOfSeats { get; set; }
        public int NoOfDoors { get; set; }
        public int NoOfCylinders { get; set; }
        public DriveType DriveType { get; set; }

        public FuelType FuelType { get; set; }
    }
}
