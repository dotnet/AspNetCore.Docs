public void Configuration(IAppBuilder app)
{
	GlobalHost.DependencyResolver.Register(
		typeof(ChatHub), 
		() => new ChatHub(new ChatMessageRepository()));

	App.MapSignalR();

	// ...
}