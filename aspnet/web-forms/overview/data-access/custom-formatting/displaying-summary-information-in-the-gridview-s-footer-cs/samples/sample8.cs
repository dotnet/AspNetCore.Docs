protected void ProductsInCategory_RowDataBound
    (object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
      ... <i>Increment the running totals</i> ...
    }
    else if (e.Row.RowType == DataControlRowType.Footer)
    {
      // Determine the average UnitPrice
      decimal avgUnitPrice = _totalUnitPrice / (decimal) _totalNonNullUnitPriceCount;
      // Display the summary data in the appropriate cells
      e.Row.Cells[1].Text = "Avg.: " + avgUnitPrice.ToString("c");
      e.Row.Cells[2].Text = "Total: " + _totalUnitsInStock.ToString();
      e.Row.Cells[3].Text = "Total: " + _totalUnitsOnOrder.ToString();
    }
}