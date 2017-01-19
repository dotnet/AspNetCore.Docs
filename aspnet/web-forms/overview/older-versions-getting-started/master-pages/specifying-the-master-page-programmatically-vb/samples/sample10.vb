Partial Class Alternate 
 Inherits BaseMasterPage
 Public Overrides Property GridMessageText() As String 
 Get
 Return String.Empty
 End Get
 Set(ByVal value As String) 
 ' Do nothing 
 End Set 
 End Property 
 Public Overrides Sub RefreshRecentProductsGrid()
 ' Do nothing 
 End Sub 
End Class