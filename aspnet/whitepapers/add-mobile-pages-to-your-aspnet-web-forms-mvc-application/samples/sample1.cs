protected void Page_PreInit(object sender, EventArgs e)
{
    if (Request.Browser.IsMobileDevice)
        MasterPageFile = "~/Mobile.Master";
}