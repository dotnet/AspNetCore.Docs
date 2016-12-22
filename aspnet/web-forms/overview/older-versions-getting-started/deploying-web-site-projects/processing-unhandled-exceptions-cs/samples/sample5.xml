protected void Application_Error(object sender, EventArgs e)
{
    // Transfer the user to the appropriate custom error page
    HttpException lastErrorWrapper = Server.GetLastError() as HttpException;

    if (lastErrorWrapper.GetHttpCode() == 404)
        Server.Transfer("~/ErrorPages/404.aspx");
    else
        Server.Transfer("~/ErrorPages/Oops.aspx");
}