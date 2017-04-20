protected void CategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
{
    if (e.Item.ItemType == ListItemType.AlternatingItem ||
        e.Item.ItemType == ListItemType.Item)
    {
        // Reference the CategoriesRow object being bound to this RepeaterItem
        Northwind.CategoriesRow category =
            (Northwind.CategoriesRow)((System.Data.DataRowView)e.Item.DataItem).Row;
        // Reference the ProductsByCategoryDataSource ObjectDataSource
        ObjectDataSource ProductsByCategoryDataSource =
            (ObjectDataSource)e.Item.FindControl("ProductsByCategoryDataSource");
        // Set the CategoryID Parameter value
        ProductsByCategoryDataSource.SelectParameters["CategoryID"].DefaultValue =
            category.CategoryID.ToString();
    }
}