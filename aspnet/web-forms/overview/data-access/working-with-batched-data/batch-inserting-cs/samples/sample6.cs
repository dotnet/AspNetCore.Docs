protected void AddProducts_Click(object sender, EventArgs e)
{
    // Make sure that the UnitPrice CompareValidators report valid data...
    if (!Page.IsValid)
        return;
    // Add new ProductsRows to a ProductsDataTable...
    Northwind.ProductsDataTable products = new Northwind.ProductsDataTable();
    for (int i = firstControlID; i <= lastControlID; i++)
    {
        // Read in the values for the product name and unit price
        string productName = ((TextBox)InsertingInterface.FindControl
            ("ProductName" + i.ToString())).Text.Trim();
        string unitPrice = ((TextBox)InsertingInterface.FindControl
            ("UnitPrice" + i.ToString())).Text.Trim();
        // Ensure that if unitPrice has a value, so does productName
        if (unitPrice.Length > 0 && productName.Length == 0)
        {
            // Display a warning and exit this event handler
            StatusLabel.Text = "If you provide a unit price you must also " +
                "include the name of the product.";
            StatusLabel.Visible = true;
            return;
        }
        // Only add the product if a product name value is provided
        if (productName.Length > 0)
        {
            // Add a new ProductsRow to the ProductsDataTable
            Northwind.ProductsRow newProduct = products.NewProductsRow();
            // Assign the values from the web page
            newProduct.ProductName = productName;
            newProduct.SupplierID = Convert.ToInt32(Suppliers.SelectedValue);
            newProduct.CategoryID = Convert.ToInt32(Categories.SelectedValue);
            if (unitPrice.Length > 0)
                newProduct.UnitPrice = Convert.ToDecimal(unitPrice);
            // Add any "default" values
            newProduct.Discontinued = false;
            newProduct.UnitsOnOrder = 0;
            products.AddProductsRow(newProduct);
        }
    }
    // If we reach here, see if there were any products added
    if (products.Count > 0)
    {
        // Add the new products to the database using a transaction
        ProductsBLL productsAPI = new ProductsBLL();
        productsAPI.UpdateWithTransaction(products);
        // Rebind the data to the grid so that the producst just added are displayed
        ProductsGrid.DataBind();
        // Display a confirmation (don't use the Warning CSS class, though)
        StatusLabel.CssClass = string.Empty;
        StatusLabel.Text = string.Format(
            "{0} products from supplier {1} have been added and filed under " + 
            "category {2}.", products.Count, Suppliers.SelectedItem.Text, 
            Categories.SelectedItem.Text);
        StatusLabel.Visible = true;
        // Revert to the display interface
        ReturnToDisplayInterface();
    }
    else
    {
        // No products supplied!
        StatusLabel.Text = "No products were added. Please enter the product " + 
            "names and unit prices in the textboxes.";
        StatusLabel.Visible = true;
    }
}