Protected Sub NewProduct_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewInsertedEventArgs) Handles NewProduct.ItemInserted
 ' Cast the loosely-typed Page.Master property and then set the GridMessageText property 
 Dim myMasterPage As Site = CType(Page.Master, Site) 
 myMasterPage.GridMessageText = String.Format("{0} added to grid...", e.Values("ProductName"))
 ' Use the strongly-typed Master property 
 Master.RefreshRecentProductsGrid()
End Sub