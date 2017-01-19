protected void SortByProductName_Click(object sender, EventArgs e)
{
    StartRowIndex = 0;
    SortExpression = "ProductName";
    Products.DataBind();
}
protected void SortByCategoryName_Click(object sender, EventArgs e)
{
    StartRowIndex = 0;
    SortExpression = "CategoryName";
    Products.DataBind();
}
protected void SortBySupplierName_Click(object sender, EventArgs e)
{
    StartRowIndex = 0;
    SortExpression = "CompanyName";
    Products.DataBind();
}