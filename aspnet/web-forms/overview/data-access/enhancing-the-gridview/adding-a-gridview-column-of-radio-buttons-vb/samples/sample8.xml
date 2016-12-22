Protected Sub Suppliers_RowCreated(sender As Object, e As GridViewRowEventArgs) _
    Handles Suppliers.RowCreated
    
    If e.Row.RowType = DataControlRowType.DataRow Then
        ' Grab a reference to the Literal control
        Dim output As Literal = _
            CType(e.Row.FindControl("RadioButtonMarkup"), Literal)
        ' Output the markup except for the "checked" attribute
        output.Text = String.Format( _
            "<input type="radio" name="SuppliersGroup" " & _
            "id="RowSelector{0}" value="{0}"", e.Row.RowIndex)
        ' See if we need to add the "checked" attribute
        If SuppliersSelectedIndex = e.Row.RowIndex Then
            output.Text &= " checked="checked""
        End If
        ' Add the closing tag
        output.Text &= " />"
    End If
End Sub