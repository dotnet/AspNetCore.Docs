void Application_Error(object sender, EventArgs e)
{
  // Code that runs when an unhandled error occurs.

  // Get last error from the server
  Exception exc = Server.GetLastError();

  if (exc is HttpUnhandledException)
  {
    if (exc.InnerException != null)
    {
      exc = new Exception(exc.InnerException.Message);
      Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax",
          true);
    }
  }
}