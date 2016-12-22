protected void Categories_ItemCommand(object source, RepeaterCommandEventArgs e)
{
    // If it's the "ListProducts" command that has been issued...
    if (string.Compare(e.CommandName, "ListProducts", true) == 0)
    {
        // Set the CategoryProductsDataSource ObjectDataSource's CategoryID parameter
        // to the CategoryID of the category that was just clicked (e.CommandArgument)...
        CategoryProductsDataSource.SelectParameters["CategoryID"].DefaultValue =
            e.CommandArgument.ToString();
    }
}