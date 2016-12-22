Protected Sub ProductsBySupplier_RowDataBound _
    (ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) _
    Handles ProductsBySupplier.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then
        ' Is this a supplier-specific user?
        If Suppliers.SelectedValue <> "-1" Then
            ' Get a reference to the ProductRow
            Dim product As Northwind.ProductsRow = _
                CType(CType(e.Row.DataItem, System.Data.DataRowView).Row, _
                Northwind.ProductsRow)
            ' Is this product discontinued?
            If product.Discontinued Then
                ' Get a reference to the Edit LinkButton
                Dim editButton As LinkButton = _
                    CType(e.Row.Cells(0).Controls(0), LinkButton)
                ' Hide the Edit button
                editButton.Visible = False
            End If
        End If
    End If
End Sub