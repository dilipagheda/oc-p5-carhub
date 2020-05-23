using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class DriveTypeComparator : IEqualityComparer<DriveType>
    {
        public bool Equals([AllowNull] DriveType x, [AllowNull] DriveType y)
        {
            if(x.Id == y.Id && x.DriveTypeName.Equals(y.DriveTypeName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] DriveType obj) { return obj.GetHashCode(); }
    }
}
