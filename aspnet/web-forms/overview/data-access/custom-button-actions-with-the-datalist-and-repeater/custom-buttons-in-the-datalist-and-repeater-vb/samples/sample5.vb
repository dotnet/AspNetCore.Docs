Protected Sub Categories_ItemCommand _
    (source As Object, e As RepeaterCommandEventArgs) _
    Handles Categories.ItemCommand
    If e.CommandName = "ShowProducts" Then
        ' Determine the CategoryID
        Dim categoryID As Integer = Convert.ToInt32(e.CommandArgument)
        ' Get the associated products from the ProudctsBLL and
        ' bind them to the BulletedList
        Dim products As BulletedList = _
            CType(e.Item.FindControl("ProductsInCategory"), BulletedList)
        Dim productsAPI As New ProductsBLL()
        products.DataSource = productsAPI.GetProductsByCategoryID(categoryID)
        products.DataBind()
    End If
End Sub