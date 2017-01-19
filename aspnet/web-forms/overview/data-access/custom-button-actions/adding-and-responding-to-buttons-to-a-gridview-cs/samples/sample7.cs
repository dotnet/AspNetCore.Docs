protected void Suppliers_ItemCommand(object sender, FormViewCommandEventArgs e)
{
    if (e.CommandName.CompareTo("DiscontinueProducts") == 0)
    {
        // The "Discontinue All Products" Button was clicked.
        // Invoke the ProductsBLL.DiscontinueAllProductsForSupplier(supplierID) method
        // First, get the SupplierID selected in the FormView
        int supplierID = (int)Suppliers.SelectedValue;
        // Next, create an instance of the ProductsBLL class
        ProductsBLL productInfo = new ProductsBLL();
        // Finally, invoke the DiscontinueAllProductsForSupplier(supplierID) method
        productInfo.DiscontinueAllProductsForSupplier(supplierID);
    }
}