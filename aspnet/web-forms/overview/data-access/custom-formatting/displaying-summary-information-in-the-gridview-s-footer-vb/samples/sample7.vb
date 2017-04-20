Protected Sub ProductsInCategory_RowDataBound _
    (sender As Object, e As GridViewRowEventArgs) _
        Handles ProductsInCategory.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then
      ... Increment the running totals ...
    ElseIf e.Row.RowType = DataControlRowType.Footer
      ... Display the summary data in the footer ...
    End If
End Sub