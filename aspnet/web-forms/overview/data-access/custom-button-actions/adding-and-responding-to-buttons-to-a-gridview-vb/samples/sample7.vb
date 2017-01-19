Protected Sub Suppliers_ItemCommand(sender As Object, e As FormViewCommandEventArgs) _
    Handles Suppliers.ItemCommand
    If e.CommandName.CompareTo("DiscontinueProducts") = 0 Then
        ' The "Discontinue All Products" Button was clicked.
        ' Invoke the ProductsBLL.DiscontinueAllProductsForSupplier(supplierID) method
        ' First, get the SupplierID selected in the FormView
        Dim supplierID As Integer = CType(Suppliers.SelectedValue, Integer)
        ' Next, create an instance of the ProductsBLL class
        Dim productInfo As New ProductsBLL()
        ' Finally, invoke the DiscontinueAllProductsForSupplier(supplierID) method
        productInfo.DiscontinueAllProductsForSupplier(supplierID)
    End If
End Sub