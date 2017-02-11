protected void Suppliers_SelectedIndexChanged(object sender, EventArgs e)
{
    if (Suppliers.SelectedValue == "-1")
    {
        // The "Show/Edit ALL" option has been selected
        SupplierDetails.DataSourceID = "AllSuppliersDataSource";
        // Reset the page index to show the first record
        SupplierDetails.PageIndex = 0;
    }
    else
        // The user picked a particular supplier
        SupplierDetails.DataSourceID = "SingleSupplierDataSource";
    // Ensure that the DetailsView is in read-only mode
    SupplierDetails.ChangeMode(DetailsViewMode.ReadOnly);
    // Need to "refresh" the DetailsView
    SupplierDetails.DataBind();
}