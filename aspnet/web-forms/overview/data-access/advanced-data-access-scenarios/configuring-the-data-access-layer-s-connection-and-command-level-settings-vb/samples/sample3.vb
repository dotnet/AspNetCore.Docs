Private WithEvents _adapter As System.Data.SqlClient.SqlDataAdapter
Private Sub InitAdapter()
    Me._adapter = New System.Data.SqlClient.SqlDataAdapter
    
    ... Code that creates the InsertCommand, UpdateCommand, ...
    ... and DeleteCommand instances - omitted for brevity ...
End Sub
Private ReadOnly Property Adapter() As System.Data.SqlClient.SqlDataAdapter
    Get
        If (Me._adapter Is Nothing) Then
            Me.InitAdapter
        End If
        Return Me._adapter
    End Get
End Property
Private _commandCollection() As System.Data.SqlClient.SqlCommand
Private Sub InitCommandCollection()
    Me._commandCollection = New System.Data.SqlClient.SqlCommand(8) {}
    ... Code that creates the command objects for the main query and the ...
    ... ProductsTableAdapter�s other eight methods - omitted for brevity ...
End Sub
Protected ReadOnly Property CommandCollection() As System.Data.SqlClient.SqlCommand()
    Get
        If (Me._commandCollection Is Nothing) Then
            Me.InitCommandCollection
        End If
        Return Me._commandCollection
    End Get
End Property