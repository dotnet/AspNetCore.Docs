protected void SendToProducts_Click(object sender, EventArgs e)
{
    // make sure one of the radio buttons has been selected
    if (SuppliersSelectedIndex < 0)
        ChooseSupplierMsg.Visible = true;
    else
    {
        // Send the user to ~/Filtering/ProductsForSupplierDetails.aspx
        int supplierID = 
            Convert.ToInt32(Suppliers.DataKeys[SuppliersSelectedIndex].Value);
        Response.Redirect(
            "~/Filtering/ProductsForSupplierDetails.aspx?SupplierID=" 
            + supplierID);
    }
}