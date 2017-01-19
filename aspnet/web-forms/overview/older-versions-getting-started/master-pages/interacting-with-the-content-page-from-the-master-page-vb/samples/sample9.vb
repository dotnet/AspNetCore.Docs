Protected Sub DoublePrice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DoublePrice.Click
 ' Double the prices
 DoublePricesDataSource.Update()

 ' Refresh RecentProducts
 RecentProducts.DataBind()

 ' Raise the PricesDoubled event
 RaiseEvent PricesDoubled(Me, EventArgs.Empty)
End Sub