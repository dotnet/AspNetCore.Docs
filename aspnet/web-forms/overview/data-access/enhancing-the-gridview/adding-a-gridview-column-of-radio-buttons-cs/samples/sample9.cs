protected void SendToProducts_Click(object sender, EventArgs e)
{
    // Send the user to ~/Filtering/ProductsForSupplierDetails.aspx
    int supplierID = 
        Convert.ToInt32(Suppliers.DataKeys[SuppliersSelectedIndex].Value);
    Response.Redirect(
        "~/Filtering/ProductsForSupplierDetails.aspx?SupplierID=" 
        + supplierID);
    }
}