Private Sub ToggleCheckState(ByVal checkState As Boolean)
    ' Iterate through the Products.Rows property
    For Each row As GridViewRow In Products.Rows
        ' Access the CheckBox
        Dim cb As CheckBox = row.FindControl("ProductSelector")
        If cb IsNot Nothing Then
            cb.Checked = checkState
        End If
    Next
End Sub