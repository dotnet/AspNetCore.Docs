Protected Sub SendToProducts_Click(sender As Object, e As EventArgs) _
    Handles SendToProducts.Click
    
    ' make sure one of the radio buttons has been selected
    If SuppliersSelectedIndex < 0 Then
        ChooseSupplierMsg.Visible = True
    Else
        ' Send the user to ~/Filtering/ProductsForSupplierDetails.aspx
        Dim supplierID As Integer = _
            Convert.ToInt32(Suppliers.DataKeys(SuppliersSelectedIndex).Value)
        Response.Redirect( _
            "~/Filtering/ProductsForSupplierDetails.aspx?SupplierID=" & _
            supplierID)
    End If
End Sub