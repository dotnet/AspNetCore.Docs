Protected Sub FirstPage_Click(sender As Object, e As EventArgs) _
    Handles FirstPage.Click
    'Return to StartRowIndex of 0 and rebind data
    StartRowIndex = 0
    Products.DataBind()
End Sub
Protected Sub PrevPage_Click(sender As Object, e As EventArgs) _
    Handles PrevPage.Click
    'Subtract MaximumRows from StartRowIndex and rebind data
    StartRowIndex -= MaximumRows
    Products.DataBind()
End Sub
Protected Sub NextPage_Click(sender As Object, e As EventArgs) _
    Handles NextPage.Click
    'Add MaximumRows to StartRowIndex and rebind data
    StartRowIndex += MaximumRows
    Products.DataBind()
End Sub
Protected Sub LastPage_Click(sender As Object, e As EventArgs) _
    Handles LastPage.Click
    'Set StartRowIndex = to last page's starting row index and rebind data
    StartRowIndex = ((TotalRowCount - 1) \ MaximumRows) * MaximumRows
    Products.DataBind()
End Sub