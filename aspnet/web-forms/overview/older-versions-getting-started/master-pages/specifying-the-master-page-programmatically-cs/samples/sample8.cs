using System; public abstract class BaseMasterPage : System.Web.UI.MasterPage
{ 
	public event EventHandler PricesDoubled; 
	protected virtual void OnPricesDoubled(EventArgs e) 
	{ 
		if (PricesDoubled != null) 
		PricesDoubled(this, e); 
	} 
	public abstract void RefreshRecentProductsGrid();
	public abstract string GridMessageText 
	{ 
		get; 
		set; 
	} 
}