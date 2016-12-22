protected override void Render(HtmlTextWriter writer)
{
    // Only add the sorting UI if the GridView is sorted
    if (!string.IsNullOrEmpty(ProductList.SortExpression))
    {
        // ... Code for finding the sorted column index removed for brevity ...
        // Reference the Table the GridView has been rendered into
        Table gridTable = (Table)ProductList.Controls[0];
        // Enumerate each TableRow, adding a sorting UI header if
        // the sorted value has changed
        string lastValue = string.Empty;
        foreach (GridViewRow gvr in ProductList.Rows)
        {
            string currentValue = gvr.Cells[sortColumnIndex].Text;
            if (lastValue.CompareTo(currentValue) != 0)
            {
                // there's been a change in value in the sorted column
                int rowIndex = gridTable.Rows.GetRowIndex(gvr);
                // Add a new sort header row
                GridViewRow sortRow = new GridViewRow(rowIndex, rowIndex,
                    DataControlRowType.DataRow, DataControlRowState.Normal);
                TableCell sortCell = new TableCell();
                sortCell.ColumnSpan = ProductList.Columns.Count;
                sortCell.Text = string.Format("{0}: {1}",
                    sortColumnHeaderText, currentValue);
                sortCell.CssClass = "SortHeaderRowStyle";
                // Add sortCell to sortRow, and sortRow to gridTable
                sortRow.Cells.Add(sortCell);
                gridTable.Controls.AddAt(rowIndex, sortRow);
                // Update lastValue
                lastValue = currentValue;
            }
        }
    }
    base.Render(writer);
}