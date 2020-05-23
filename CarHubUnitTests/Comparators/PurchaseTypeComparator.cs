using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class PurchaseTypeComparator : IEqualityComparer<PurchaseType>
    {
        public bool Equals([AllowNull] PurchaseType x, [AllowNull] PurchaseType y)
        {
            if(x.Id == y.Id && x.PurchaseTypeName.Equals(y.PurchaseTypeName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] PurchaseType obj) { return obj.GetHashCode(); }
    }
}
