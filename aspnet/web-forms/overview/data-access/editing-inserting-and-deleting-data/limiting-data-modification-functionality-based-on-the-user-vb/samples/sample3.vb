Protected Sub Suppliers_SelectedIndexChanged _
    (ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Suppliers.SelectedIndexChanged
    If Suppliers.SelectedValue = "-1" Then
        ' The "Show/Edit ALL" option has been selected
        SupplierDetails.DataSourceID = "AllSuppliersDataSource"
        ' Reset the page index to show the first record
        SupplierDetails.PageIndex = 0
    Else
        ' The user picked a particular supplier
        SupplierDetails.DataSourceID = "SingleSupplierDataSource"
    End If
    ' Ensure that the DetailsView and GridView are in read-only mode
    SupplierDetails.ChangeMode(DetailsViewMode.ReadOnly)
    ' Need to "refresh" the DetailsView
    SupplierDetails.DataBind()
End Sub