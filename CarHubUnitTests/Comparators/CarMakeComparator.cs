using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class CarMakeComparator : IEqualityComparer<CarMake>
    {
        public bool Equals([AllowNull] CarMake x, [AllowNull] CarMake y)
        {
            if(x.Id == y.Id && x.MakeName.Equals(y.MakeName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] CarMake obj) { return obj.GetHashCode(); }
    }
}
