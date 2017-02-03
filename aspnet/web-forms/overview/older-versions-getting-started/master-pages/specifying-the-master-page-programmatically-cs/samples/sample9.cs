public partial class Site : BaseMasterPage { 
	protected void Page_Load(object sender, EventArgs e) 
	{ 
		DateDisplay.Text = DateTime.Now.ToString("dddd, MMMM dd"); 
	} 
	public override void RefreshRecentProductsGrid()
	{ 
		RecentProducts.DataBind();
	} 
	public override string GridMessageText
	{ 
		get 
		{
			return GridMessage.Text;
		} 
		set
		{
			GridMessage.Text = value; 
		} 
	}
	protected void DoublePrice_Click(object sender, EventArgs e) 
	{ 
		// Double the prices 
		DoublePricesDataSource.Update();
		// Refresh RecentProducts 
		RecentProducts.DataBind();
		// Raise the PricesDoubled event
		base.OnPricesDoubled(EventArgs.Empty);
	} 
}