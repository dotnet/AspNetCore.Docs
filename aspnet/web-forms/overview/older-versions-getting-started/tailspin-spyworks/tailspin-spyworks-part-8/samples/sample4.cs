void Application_Error(object sender, EventArgs e)
 {
	Exception myEx =  Server.GetLastError();
	String RedirectUrlString = "~/Error.aspx?InnerErr=" + 
		myEx.InnerException.Message.ToString() + "&Err=" + myEx.Message.ToString();
	Response.Redirect(RedirectUrlString);
 }