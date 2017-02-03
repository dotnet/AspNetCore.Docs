public partial class Admin_AdminNested : BaseMasterPage 
{ 
	public override void RefreshRecentProductsGrid() 
	{ 
		Master.RefreshRecentProductsGrid();
	} 
	public override string GridMessageText
	{ 
		get 
		{
			return Master.GridMessageText;
		} 
		set
		{ 
			Master.GridMessageText = value; 
		} 
	}
}