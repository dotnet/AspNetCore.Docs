Private Property PageIndex() As Integer
 Get
 Dim o As Object = ViewState("PageIndex")
 If o Is Nothing Then
 Return 0
 Else
 Return Convert.ToInt32(o)
 End If
 End Get
 Set(ByVal Value As Integer)
 ViewState("PageIndex") = Value
 End Set
End Property

Private ReadOnly Property PageSize() As Integer
 Get
 Return 10
 End Get
End Property