using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class FuelTypeComparator : IEqualityComparer<FuelType>
    {
        public bool Equals([AllowNull] FuelType x, [AllowNull] FuelType y)
        {
            if(x.Id == y.Id && x.FuelTypeName.Equals(y.FuelTypeName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] FuelType obj) { return obj.GetHashCode(); }
    }
}
