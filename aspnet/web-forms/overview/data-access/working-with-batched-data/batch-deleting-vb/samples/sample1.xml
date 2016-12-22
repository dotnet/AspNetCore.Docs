Partial Class BatchData_BatchDelete
    Inherits System.Web.UI.Page
    Protected Sub DeleteSelectedProducts_Click(sender As Object, e As EventArgs) _
        Handles DeleteSelectedProducts.Click
        
        Dim atLeastOneRowDeleted As Boolean = False
        ' Iterate through the Products.Rows property
        For Each row As GridViewRow In Products.Rows
            ' Access the CheckBox
            Dim cb As CheckBox = row.FindControl("ProductSelector")
            If cb IsNot Nothing AndAlso cb.Checked Then
                ' Delete row! (Well, not really...)
                atLeastOneRowDeleted = True
                ' First, get the ProductID for the selected row
                Dim productID As Integer = _
                    Convert.ToInt32(Products.DataKeys(row.RowIndex).Value)
                ' "Delete" the row
                DeleteResults.Text &= String.Format _
                    ("This would have deleted ProductID {0}<br />", productID)
                '... To actually delete the product, use ...
                ' Dim productAPI As New ProductsBLL
                ' productAPI.DeleteProduct(productID)
                '............................................
            End If
        Next
        ' Show the Label if at least one row was deleted...
        DeleteResults.Visible = atLeastOneRowDeleted
    End Sub
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
    Protected Sub CheckAll_Click(sender As Object, e As EventArgs) _
        Handles CheckAll.Click
        ToggleCheckState(True)
    End Sub
    Protected Sub UncheckAll_Click(sender As Object, e As EventArgs) _
        Handles UncheckAll.Click
        ToggleCheckState(False)
    End Sub
End Class