Protected Sub ListProducts_Click(sender As Object, e As EventArgs) _
    Handles ListProducts.Click
    
    ' make sure one of the radio buttons has been selected
    If SuppliersSelectedIndex < 0 Then
        ChooseSupplierMsg.Visible = True
        ProductsBySupplierPanel.Visible = False
    Else
        ' Set the GridView's SelectedIndex
        Suppliers.SelectedIndex = SuppliersSelectedIndex
        ' Show the ProductsBySupplierPanel panel
        ProductsBySupplierPanel.Visible = True
    End If
End Sub