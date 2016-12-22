Private _connection As System.Data.SqlClient.SqlConnection
Private Sub InitConnection()
    Me._connection = New System.Data.SqlClient.SqlConnection
    Me._connection.ConnectionString = _
        ConfigurationManager.ConnectionStrings("NORTHWNDConnectionString").ConnectionString
End Sub
Friend Property Connection() As System.Data.SqlClient.SqlConnection
    Get
        If (Me._connection Is Nothing) Then
            Me.InitConnection
        End If
        Return Me._connection
    End Get
    Set
        Me._connection = value
        If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
            Me.Adapter.InsertCommand.Connection = value
        End If
        If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
            Me.Adapter.DeleteCommand.Connection = value
        End If
        If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
            Me.Adapter.UpdateCommand.Connection = value
        End If
        Dim i As Integer = 0
        Do While (i < Me.CommandCollection.Length)
            If (Not (Me.CommandCollection(i)) Is Nothing) Then
                CType(Me.CommandCollection(i), _
                    System.Data.SqlClient.SqlCommand).Connection = value
            End If
            i = (i + 1)
        Loop
    End Set
End Property