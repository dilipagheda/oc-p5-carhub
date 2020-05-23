using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class BodyTypeComparator : IEqualityComparer<BodyType>
    {
        public bool Equals([AllowNull] BodyType x, [AllowNull] BodyType y)
        {
            if(x.Id == y.Id && x.BodyTypeName.Equals(y.BodyTypeName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] BodyType obj) { return obj.GetHashCode(); }
    }
}
