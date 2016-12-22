protected void Application_Start(object sender, EventArgs e) 
{
    // Map all hubs to "/signalr"
    RouteTable.Routes.MapHubs();
    // Map the Echo PersistentConnection to "/echo"
    RouteTable.Routes.MapConnection<myconnection>("echo", "/echo");
}