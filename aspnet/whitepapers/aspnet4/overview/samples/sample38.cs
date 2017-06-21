public class Global : System.Web.HttpApplication 
{ 
	void Application_Start(object sender, EventArgs e) 
	{ 
		RouteTable.Routes.MapPageRoute("SearchRoute", 
		  "search/{searchterm}", "~/search.aspx"); 
		RouteTable.Routes.MapPageRoute("UserRoute", 
		  "users/{username}", "~/users.aspx"); 
	} 
}