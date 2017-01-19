protected void SuppliersProducts_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if (e.CommandName.CompareTo("IncreasePrice") == 0 ||
        e.CommandName.CompareTo("DecreasePrice") == 0)
    {
        // The Increase Price or Decrease Price Button has been clicked
        // Determine the ID of the product whose price was adjusted
        int productID =
            (int)SuppliersProducts.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
        // Determine how much to adjust the price
        decimal percentageAdjust;
        if (e.CommandName.CompareTo("IncreasePrice") == 0)
            percentageAdjust = 1.1M;
        else
            percentageAdjust = 0.9M;

        // Adjust the price
        ProductsBLL productInfo = new ProductsBLL();
        productInfo.UpdateProduct(percentageAdjust, productID);
    }
}