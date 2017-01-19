Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreInit
 AddHandler Master.PricesDoubled, AddressOf Master_PricesDoubled
End Sub