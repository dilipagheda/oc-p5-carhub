using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class InventoryStatusComparator : IEqualityComparer<InventoryStatus>
    {
        public bool Equals([AllowNull] InventoryStatus x, [AllowNull] InventoryStatus y)
        {
            if(x.Id == y.Id && x.Status.Equals(y.Status))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] InventoryStatus obj) { return obj.GetHashCode(); }
    }
}
