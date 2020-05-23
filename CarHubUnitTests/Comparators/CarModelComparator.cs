using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class CarModelComparator : IEqualityComparer<CarModel>
    {
        public bool Equals([AllowNull] CarModel x, [AllowNull] CarModel y)
        {
            if(x.Id == y.Id && x.ModelName.Equals(y.ModelName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] CarModel obj) { return obj.GetHashCode(); }
    }
}
