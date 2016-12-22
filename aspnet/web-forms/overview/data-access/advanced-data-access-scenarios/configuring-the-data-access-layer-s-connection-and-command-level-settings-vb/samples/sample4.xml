Public Sub SetCommandTimeout(ByVal timeout As Integer)
    If Me.Adapter.InsertCommand IsNot Nothing Then
        Me.Adapter.InsertCommand.CommandTimeout = timeout
    End If
    If Me.Adapter.DeleteCommand IsNot Nothing Then
        Me.Adapter.DeleteCommand.CommandTimeout = timeout
    End If
    If Me.Adapter.UpdateCommand IsNot Nothing Then
        Me.Adapter.UpdateCommand.CommandTimeout = timeout
    End If
    For i As Integer = 0 To Me.CommandCollection.Length - 1
        If Me.CommandCollection(i) IsNot Nothing Then
            Me.CommandCollection(i).CommandTimeout = timeout
        End If
    Next
End Sub