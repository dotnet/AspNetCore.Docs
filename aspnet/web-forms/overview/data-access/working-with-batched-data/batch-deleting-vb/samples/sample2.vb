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