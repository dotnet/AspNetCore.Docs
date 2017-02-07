Protected Sub GridView1_RowDataBound(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) _
    Handles GridView1.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
        ' reference the Delete LinkButton
        Dim db As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)

        ' Get information about the product bound to the row
        Dim product As Northwind.ProductsRow = _
            CType(CType(e.Row.DataItem, System.Data.DataRowView).Row, _
            Northwind.ProductsRow)

        db.OnClientClick = String.Format( _
            "return confirm('Are you certain you want to delete the {0} product?');", _
            product.ProductName.Replace("'", "\'"))
    End If
End Sub