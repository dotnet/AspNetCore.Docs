Protected Sub AddProducts_Click(sender As Object, e As EventArgs) _
    Handles AddProducts.Click
    ' TODO: Save the products
    ' Revert to the display interface
    ReturnToDisplayInterface()
End Sub
Protected Sub CancelButton_Click(sender As Object, e As EventArgs) _
    Handles CancelButton.Click
    ' Revert to the display interface
    ReturnToDisplayInterface()
End Sub
Const firstControlID As Integer = 1
Const lastControlID As Integer = 5
Private Sub ReturnToDisplayInterface()
    ' Reset the control values in the inserting interface
    Suppliers.SelectedIndex = 0
    Categories.SelectedIndex = 0
    For i As Integer = firstControlID To lastControlID
        CType(InsertingInterface.FindControl _
            ("ProductName" + i.ToString()), TextBox).Text = String.Empty
        CType(InsertingInterface.FindControl _
            ("UnitPrice" + i.ToString()), TextBox).Text = String.Empty
    Next
    DisplayInterface.Visible = True
    InsertingInterface.Visible = False
End Sub