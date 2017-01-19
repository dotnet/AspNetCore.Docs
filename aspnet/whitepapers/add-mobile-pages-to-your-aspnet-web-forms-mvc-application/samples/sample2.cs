void Session_Start(object sender, EventArgs e)
{
    // Redirect mobile users to the mobile home page
    HttpRequest httpRequest = HttpContext.Current.Request;
    if (httpRequest.Browser.IsMobileDevice)
    {
        string path = httpRequest.Url.PathAndQuery;
        bool isOnMobilePage = path.StartsWith("/Mobile/", 
                               StringComparison.OrdinalIgnoreCase);
        if (!isOnMobilePage)
        {
            string redirectTo = "~/Mobile/";

            // Could also add special logic to redirect from certain 
            // recognized pages to the mobile equivalents of those 
            // pages (where they exist). For example,
            // if (HttpContext.Current.Handler is UserRegistration)
            //     redirectTo = "~/Mobile/Register.aspx";

            HttpContext.Current.Response.Redirect(redirectTo);
        }
    }
}