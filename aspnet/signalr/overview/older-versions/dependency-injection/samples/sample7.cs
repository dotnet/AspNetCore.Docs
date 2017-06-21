protected void Application_Start()
{
	GlobalHost.DependencyResolver.Register(
		typeof(ChatHub), 
		() => new ChatHub(new ChatMessageRepository()));

	RouteTable.Routes.MapHubs();

	// ...
}