protected void NewProduct_ItemInserted(object sender, DetailsViewInsertedEventArgs e) 
{ 
	// Cast the loosely-typed Page.Master property and then set the GridMessageText property 
	Site myMasterPage = Page.Master as Site; 
	myMasterPage.GridMessageText = string.Format("{0} added to grid...", e.Values["ProductName"]); 
	// Use the strongly-typed Master property 
	Master.RefreshRecentProductsGrid();
}