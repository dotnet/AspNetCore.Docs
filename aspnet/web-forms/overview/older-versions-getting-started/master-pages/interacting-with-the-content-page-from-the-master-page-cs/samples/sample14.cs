protected void Page_PreInit(object sender, EventArgs e)
{
	// Create an event handler for the master page's PricesDoubled event
	Master.PricesDoubled += new EventHandler(Master_PricesDoubled);
}