Protected Sub GridView1_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) _
    Handles GridView1.RowDeleted
    ' If we just deleted the last row in the GridView, decrement the PageIndex
    If e.Exception Is Nothing AndAlso GridView1.Rows.Count = 1 Then
        ' we just deleted the last row
        GridView1.PageIndex = Math.Max(0, GridView1.PageIndex - 1)
    End If
End Sub