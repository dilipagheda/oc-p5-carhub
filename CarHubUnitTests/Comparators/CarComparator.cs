using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class CarComparator : IEqualityComparer<Car>
    {
        public bool Equals([AllowNull] Car x, [AllowNull] Car y)
        {
            if(x.Id.Equals(y.Id) &&
                x.Year == y.Year &&
                x.CarMakeId == y.CarMakeId &&
                x.CarModelId == y.CarModelId &&
                x.TrimId == y.TrimId &&
                x.Kms == y.Kms &&
                x.TransmissionType == y.TransmissionType &&
                x.RegoNumber == y.RegoNumber &&
                x.RegoExpiry == y.RegoExpiry &&
                x.Description == y.Description &&
                x.ColorId == y.ColorId &&
                x.BodyTypeId == y.BodyTypeId &&
                x.NoOfSeats == y.NoOfSeats &&
                x.NoOfCylinders == y.NoOfCylinders &&
                x.NoOfDoors == y.NoOfDoors &&
                x.DriveTypeId == y.DriveTypeId &&
                x.FuelTypeId == y.FuelTypeId)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] Car obj) { return obj.GetHashCode(); }
    }
}
