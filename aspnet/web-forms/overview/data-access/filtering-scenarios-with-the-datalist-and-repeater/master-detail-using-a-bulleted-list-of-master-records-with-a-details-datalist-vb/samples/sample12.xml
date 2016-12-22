Protected Sub Categories_ItemCommand(source As Object, e As RepeaterCommandEventArgs) _
    Handles Categories.ItemCommand
    ' If it's the "ListProducts" command that has been issued...
    If String.Compare(e.CommandName, "ListProducts", True) = 0 Then
        ' Set the CategoryProductsDataSource ObjectDataSource's CategoryID parameter
        ' to the CategoryID of the category that was just clicked (e.CommandArgument)...
        CategoryProductsDataSource.SelectParameters("CategoryID").DefaultValue = _
            e.CommandArgument.ToString()
    End If
End Sub