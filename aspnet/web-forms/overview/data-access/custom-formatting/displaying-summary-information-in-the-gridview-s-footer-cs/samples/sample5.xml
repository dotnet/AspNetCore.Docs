// Class-scope, running total variables...
decimal _totalUnitPrice = 0m;
int _totalNonNullUnitPriceCount = 0;
int _totalUnitsInStock = 0;
int _totalUnitsOnOrder = 0;
protected void ProductsInCategory_RowDataBound(object sender,
  GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        // Reference the ProductsRow via the e.Row.DataItem property
        Northwind.ProductsRow product =
          (Northwind.ProductsRow)
          ((System.Data.DataRowView)e.Row.DataItem).Row;
        // Increment the running totals (if they are not NULL!)
        if (!product.IsUnitPriceNull())
        {
            _totalUnitPrice += product.UnitPrice;
            _totalNonNullUnitPriceCount++;
        }
        if (!product.IsUnitsInStockNull())
            _totalUnitsInStock += product.UnitsInStock;
        if (!product.IsUnitsOnOrderNull())
            _totalUnitsOnOrder += product.UnitsOnOrder;
    }
}