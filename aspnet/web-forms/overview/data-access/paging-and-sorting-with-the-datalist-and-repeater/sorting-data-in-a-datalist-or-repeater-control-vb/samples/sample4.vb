Protected Sub ProductsDataSource_Selecting _
    (ByVal sender As Object, ByVal e As ObjectDataSourceSelectingEventArgs) _
    Handles ProductsDataSource.Selecting
    ' Have the ObjectDataSource sort the results by the
    ' selected sort expression
    e.Arguments.SortExpression = SortBy.SelectedValue
End Sub