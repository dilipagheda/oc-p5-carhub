using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class ColorComparator : IEqualityComparer<Color>
    {
        public bool Equals([AllowNull] Color x, [AllowNull] Color y)
        {
            if(x.Id == y.Id && x.ColorName.Equals(y.ColorName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] Color obj) { return obj.GetHashCode(); }
    }
}
