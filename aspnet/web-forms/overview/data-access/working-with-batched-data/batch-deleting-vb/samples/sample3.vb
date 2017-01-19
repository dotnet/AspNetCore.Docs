Protected Sub DeleteSelectedProducts_Click(sender As Object, e As EventArgs) _
    Handles DeleteSelectedProducts.Click
    
    ' Create a List to hold the ProductID values to delete
    Dim productIDsToDelete As New System.Collections.Generic.List(Of Integer)
    ' Iterate through the Products.Rows property
    For Each row As GridViewRow In Products.Rows
        ' Access the CheckBox
        Dim cb As CheckBox = CType(row.FindControl("ProductSelector"), CheckBox)
        If cb IsNot Nothing AndAlso cb.Checked Then
            ' Save the ProductID value for deletion
            ' First, get the ProductID for the selected row
            Dim productID As Integer = _
                Convert.ToInt32(Products.DataKeys(row.RowIndex).Value)
            ' Add it to the List...
            productIDsToDelete.Add(productID)
            ' Add a confirmation message
            DeleteResults.Text &= String.Format _
                ("ProductID {0} has been deleted<br />", productID)
        End If
    Next
    ' Call the DeleteProductsWithTransaction method and show the Label 
    ' if at least one row was deleted...
    If productIDsToDelete.Count > 0 Then
        Dim productAPI As New ProductsBLL()
        productAPI.DeleteProductsWithTransaction(productIDsToDelete)
        DeleteResults.Visible = True
        ' Rebind the data to the GridView
        Products.DataBind()
    End If
End Sub