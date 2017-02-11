protected void Categories_ItemDataBound(object sender, RepeaterItemEventArgs e)
{
    // Make sure we're working with a data item...
    if (e.Item.ItemType == ListItemType.Item ||
        e.Item.ItemType == ListItemType.AlternatingItem)
    {
        // Reference the CategoriesRow instance bound to this RepeaterItem
        Northwind.CategoriesRow category =
            (Northwind.CategoriesRow) ((System.Data.DataRowView) e.Item.DataItem).Row;
        // Determine how many products are in this category
        NorthwindTableAdapters.ProductsTableAdapter productsAPI =
            new NorthwindTableAdapters.ProductsTableAdapter();
        int productCount =
            productsAPI.GetProductsByCategoryID(category.CategoryID).Count;
        // Reference the ViewCategory LinkButton and set its Text property
        LinkButton ViewCategory = (LinkButton)e.Item.FindControl("ViewCategory");
        ViewCategory.Text =
            string.Format("{0} ({1:N0})", category.CategoryName, productCount);
    }
}