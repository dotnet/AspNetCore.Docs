Protected Sub SuppliersProducts_RowCommand _
    (sender As Object, e As GridViewCommandEventArgs) _
        Handles SuppliersProducts.RowCommand
    If e.CommandName.CompareTo("IncreasePrice") = 0 OrElse _
       e.CommandName.CompareTo("DecreasePrice") = 0 Then
        ' The Increase Price or Decrease Price Button has been clicked
        ' Determine the ID of the product whose price was adjusted
        Dim productID As Integer = Convert.ToInt32( _
            SuppliersProducts.DataKeys(Convert.ToInt32(e.CommandArgument)).Value)
        ' Determine how much to adjust the price
        Dim percentageAdjust As Decimal
        If e.CommandName.CompareTo("IncreasePrice") = 0 Then
            percentageAdjust = 1.1
        Else
            percentageAdjust = 0.9
        End If
        ' Adjust the price
        Dim productInfo As New ProductsBLL()
        productInfo.UpdateProduct(percentageAdjust, productID)
    End If
End Sub