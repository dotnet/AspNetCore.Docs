Public MustInherit Class BaseMasterPage 
 Inherits System.Web.UI.MasterPage 
 Public Event PricesDoubled As EventHandler
 Protected Overridable Sub OnPricesDoubled(ByVal e As EventArgs)
 RaiseEvent PricesDoubled(Me, e)
 End Sub
 Public MustOverride Sub RefreshRecentProductsGrid() 
 Public MustOverride Property GridMessageText() As String 
End Class