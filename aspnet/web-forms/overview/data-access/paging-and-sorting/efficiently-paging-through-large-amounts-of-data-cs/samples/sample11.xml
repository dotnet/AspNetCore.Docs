protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
{
    // If we just deleted the last row in the GridView, decrement the PageIndex
    if (e.Exception == null && GridView1.Rows.Count == 1)
        // we just deleted the last row
        GridView1.PageIndex = Math.Max(0, GridView1.PageIndex - 1);
}