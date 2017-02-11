//--------------------------------------------------------------------------------------+
public static IOrderedDictionary GetValues(GridViewRow row)
{
  IOrderedDictionary values = new OrderedDictionary();
  foreach (DataControlFieldCell cell in row.Cells)
    {
    if (cell.Visible)
      {
      // Extract values from the cell
      cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
      }
    }
    return values;
}