protected void ListProducts_Click(object sender, EventArgs e)
{
    // make sure one of the radio buttons has been selected
    if (SuppliersSelectedIndex < 0)
    {
        ChooseSupplierMsg.Visible = true;
        ProductsBySupplierPanel.Visible = false;
    }
    else
    {
        // Set the GridView's SelectedIndex
        Suppliers.SelectedIndex = SuppliersSelectedIndex;
        // Show the ProductsBySupplierPanel panel
        ProductsBySupplierPanel.Visible = true;
    }
}