Protected Sub ProductsDataSourceDeclarative_Selecting _
    (sender As Object, e As ObjectDataSourceSelectingEventArgs) _
    Handles ProductsDataSourceDeclarative.Selecting
    ODSEvents.Text = "-- Selecting event fired"
End Sub