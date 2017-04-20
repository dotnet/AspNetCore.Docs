protected void SortPriceDescending_Click(object sender, EventArgs e)
{
    // Sort by UnitPrice in descending order
    Products.Sort("UnitPrice", SortDirection.Descending);
}