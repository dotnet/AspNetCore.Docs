Protected Sub ObjectDataSource1_Selecting _
    (sender As Object, e As ObjectDataSourceSelectingEventArgs) _
        Handles ObjectDataSource1.Selecting
    e.InputParameters("month") = DateTime.Now.Month
End Sub