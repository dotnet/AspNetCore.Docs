Protected Sub ProductsDataSource_Selecting(sender As Object, _
    e As ObjectDataSourceSelectingEventArgs) _
    Handles ProductsDataSource.Selecting
    e.InputParameters("startRowIndex") = 0
    e.InputParameters("maximumRows") = 5
End Sub