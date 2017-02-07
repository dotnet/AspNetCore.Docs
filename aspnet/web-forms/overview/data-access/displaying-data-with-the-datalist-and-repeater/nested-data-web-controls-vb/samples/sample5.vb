Protected Sub CategoryList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) _
    Handles CategoryList.ItemDataBound
    If e.Item.ItemType = ListItemType.AlternatingItem _
        OrElse e.Item.ItemType = ListItemType.Item Then
        ' Reference the CategoriesRow object being bound to this RepeaterItem
        Dim category As Northwind.CategoriesRow = _
            CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                Northwind.CategoriesRow)
        ' Reference the ProductsByCategoryDataSource ObjectDataSource
        Dim ProductsByCategoryDataSource As ObjectDataSource = _
            CType(e.Item.FindControl("ProductsByCategoryDataSource"), _
                ObjectDataSource)
        ' Set the CategoryID Parameter value
        ProductsByCategoryDataSource.SelectParameters("CategoryID").DefaultValue = _
            category.CategoryID.ToString()
    End If
End Sub