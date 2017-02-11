private void BatchUpdateAlternate()
{
    // Enumerate the GridView's Rows collection and create a ProductRow
    ProductsBLL productsAPI = new ProductsBLL();
    Northwind.ProductsDataTable products = new Northwind.ProductsDataTable();
    foreach (GridViewRow gvRow in ProductsGrid.Rows)
    {
        // Create a new ProductRow instance
        int productID = Convert.ToInt32(ProductsGrid.DataKeys[gvRow.RowIndex].Value);
        
        Northwind.ProductsDataTable currentProductDataTable = 
            productsAPI.GetProductByProductID(productID);
        if (currentProductDataTable.Rows.Count > 0)
        {
            Northwind.ProductsRow product = currentProductDataTable[0];
            // Programmatically access the form field elements in the 
            // current GridViewRow
            TextBox productName = (TextBox)gvRow.FindControl("ProductName");
            DropDownList categories = 
                (DropDownList)gvRow.FindControl("Categories");
            TextBox unitPrice = (TextBox)gvRow.FindControl("UnitPrice");
            CheckBox discontinued = 
                (CheckBox)gvRow.FindControl("Discontinued");
            // Assign the user-entered values to the current ProductRow
            product.ProductName = productName.Text.Trim();
            if (categories.SelectedIndex == 0) 
                product.SetCategoryIDNull(); 
            else 
                product.CategoryID = Convert.ToInt32(categories.SelectedValue);
            if (unitPrice.Text.Trim().Length == 0) 
                product.SetUnitPriceNull(); 
            else 
                product.UnitPrice = Convert.ToDecimal(unitPrice.Text);
            product.Discontinued = discontinued.Checked;
            // Import the ProductRow into the products DataTable
            products.ImportRow(product);
        }
    }
    // Now have the BLL update the products data using a transaction
    productsAPI.UpdateProductsWithTransaction(products);
}