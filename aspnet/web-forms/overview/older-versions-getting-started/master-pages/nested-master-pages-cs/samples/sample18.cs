public class AdminBasePage : BasePage 
{ 
	protected override void SetMasterPageFile() 
	{ 
		this.MasterPageFile = "~/Admin/AdminNested.master"; 
		Page.Master.MasterPageFile = base.GetMasterPageFileFromSession(); 
	} 
}