using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarHubUnitTests.Comparators
{
    public class InventoryComparator : IEqualityComparer<Inventory>
    {
        public bool Equals([AllowNull] Inventory x, [AllowNull] Inventory y)
        {
            if(x.Id.Equals(y.Id) &&
                x.CarId.Equals(y.CarId) &&
                x.SaleDate.Equals(y.SaleDate) &&
                x.SalePrice.Equals(y.SalePrice) &&
                x.PurchaseDate.Equals(y.PurchaseDate) &&
                x.PurchasePrice.Equals(y.PurchasePrice) &&
                x.PurchaseTypeId.Equals(y.PurchaseTypeId) &&
                x.InventoryStatusId.Equals(y.InventoryStatusId) &&
                x.LotDate.Equals(y.LotDate) &&
                x.IsFeatured == y.IsFeatured)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] Inventory obj) { return obj.GetHashCode(); }
    }
}
