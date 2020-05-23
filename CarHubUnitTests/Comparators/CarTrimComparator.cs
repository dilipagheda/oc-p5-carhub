using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class CarTrimComparator : IEqualityComparer<Trim>
    {
        public bool Equals([AllowNull] Trim x, [AllowNull] Trim y)
        {
            if(x.Id == y.Id && x.TrimName.Equals(y.TrimName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] Trim obj) { return obj.GetHashCode(); }
    }
}
