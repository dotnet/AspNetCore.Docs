Protected Sub Categories_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
    ' Make sure we're working with a data item...
    If e.Item.ItemType = ListItemType.Item OrElse _
        e.Item.ItemType = ListItemType.AlternatingItem Then
        ' Reference the CategoriesRow instance bound to this RepeaterItem
        Dim category As Northwind.CategoriesRow = _
            CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                Northwind.CategoriesRow)
        ' Determine how many products are in this category
        Dim productsAPI As New NorthwindTableAdapters.ProductsTableAdapter
        Dim productCount As Integer = _
            productsAPI.GetProductsByCategoryID(category.CategoryID).Count
        ' Reference the ViewCategory LinkButton and set its Text property
        Dim ViewCategory As LinkButton = _
            CType(e.Item.FindControl("ViewCategory"), LinkButton)
        ViewCategory.Text = _
            String.Format("{0} ({1:N0})", category.CategoryName, productCount)
    End If
End Sub