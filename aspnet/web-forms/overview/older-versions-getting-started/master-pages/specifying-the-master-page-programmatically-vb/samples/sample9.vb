Partial Class Site 
 Inherits BaseMasterPage
 Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load 
 DateDisplay.Text = DateTime.Now.ToString("dddd, MMMM dd")
 End Sub
 Public Overrides Sub RefreshRecentProductsGrid() 
 RecentProducts.DataBind()
 End Sub 
 Public Overrides Property GridMessageText() As String 
 Get
 Return GridMessage.Text
 End Get 
 Set(ByVal Value As String) 
 GridMessage.Text = Value 
 End Set
 End Property 
 Protected Sub DoublePrice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DoublePrice.Click 
 ' Double the prices 
 DoublePricesDataSource.Update()
 ' Refresh RecentProducts 
 RecentProducts.DataBind()
 ' Raise the PricesDoubled event
 MyBase.OnPricesDoubled(EventArgs.Empty)
 End Sub 
End Class