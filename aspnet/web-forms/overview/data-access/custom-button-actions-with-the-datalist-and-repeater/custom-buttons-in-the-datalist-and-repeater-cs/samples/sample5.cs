protected void Categories_ItemCommand(object source, RepeaterCommandEventArgs e)
{
    if (e.CommandName == "ShowProducts")
    {
        // Determine the CategoryID
        int categoryID = Convert.ToInt32(e.CommandArgument);
        // Get the associated products from the ProudctsBLL and bind
        // them to the BulletedList
        BulletedList products =
            (BulletedList)e.Item.FindControl("ProductsInCategory");
        ProductsBLL productsAPI = new ProductsBLL();
        products.DataSource =
            productsAPI.GetProductsByCategoryID(categoryID);
        products.DataBind());
    }
}