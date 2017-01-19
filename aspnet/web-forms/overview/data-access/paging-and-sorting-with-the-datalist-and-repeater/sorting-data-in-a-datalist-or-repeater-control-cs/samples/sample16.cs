protected void FirstPage_Click(object sender, EventArgs e)
{
    // Return to StartRowIndex of 0 and rebind data
    StartRowIndex = 0;
    Products.DataBind();
}
protected void PrevPage_Click(object sender, EventArgs e)
{
    // Subtract MaximumRows from StartRowIndex and rebind data
    StartRowIndex -= MaximumRows;
    Products.DataBind();
}
protected void NextPage_Click(object sender, EventArgs e)
{
    // Add MaximumRows to StartRowIndex and rebind data
    StartRowIndex += MaximumRows;
    Products.DataBind();
}
protected void LastPage_Click(object sender, EventArgs e)
{
    // Set StartRowIndex = to last page's starting row index and rebind data
    StartRowIndex = ((TotalRowCount - 1) / MaximumRows) * MaximumRows;
    Products.DataBind();
}