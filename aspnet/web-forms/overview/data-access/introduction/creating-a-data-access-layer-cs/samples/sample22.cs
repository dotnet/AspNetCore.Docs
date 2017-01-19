using System;
using System.Data;
using NorthwindTableAdapters;
public partial class Northwind
{
    public partial class SuppliersRow
    {
        public Northwind.ProductsDataTable GetProducts()
        {
            ProductsTableAdapter productsAdapter =
             new ProductsTableAdapter();
            return
              productsAdapter.GetProductsBySupplierID(this.SupplierID);
        }
    }
}