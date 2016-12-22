protected override void Render(HtmlTextWriter writer)
{
    // Only add the sorting UI if the GridView is sorted
    if (!string.IsNullOrEmpty(ProductList.SortExpression))
    {
        // Determine the index and HeaderText of the column that
        //the data is sorted by
        int sortColumnIndex = -1;
        string sortColumnHeaderText = string.Empty;
        for (int i = 0; i < ProductList.Columns.Count; i++)
        {
            if (ProductList.Columns[i].SortExpression.CompareTo(ProductList.SortExpression)
                == 0)
            {
                sortColumnIndex = i;
                sortColumnHeaderText = ProductList.Columns[i].HeaderText;
                break;
            }
        }
        // TODO: Scan the rows for differences in the sorted column�s values
}