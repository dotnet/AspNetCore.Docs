Private Property UsernameToMatch() As String
 Get
 Dim o As Object = ViewState("UsernameToMatch")
 If o Is Nothing Then
 Return String.Empty
 Else
 Return o.ToString()
 End If
 End Get
 Set(ByVal Value As String)
 ViewState("UsernameToMatch") = Value
 End Set
End Property