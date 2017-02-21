protected void DoublePrice_Click(object sender, EventArgs e)
{
	// Double the prices
	DoublePricesDataSource.Update();

	// Refresh RecentProducts
	RecentProducts.DataBind();

	// Raise the PricesDoubled event
	if (PricesDoubled != null)
	PricesDoubled(this, EventArgs.Empty);
}