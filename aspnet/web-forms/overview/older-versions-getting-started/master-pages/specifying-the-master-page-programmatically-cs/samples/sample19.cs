protected override void OnPreInit(EventArgs e) 
{ 
	SetMasterPageFile();
	base.OnPreInit(e); 
} 
protected virtual void SetMasterPageFile()
{ 
	this.MasterPageFile = GetMasterPageFileFromSession();
} 
protected string GetMasterPageFileFromSession() 
{ 
	if (Session["MyMasterPage"] == null) 
		return "~/Site.master";
	else
		return Session["MyMasterPage"].ToString(); 
}