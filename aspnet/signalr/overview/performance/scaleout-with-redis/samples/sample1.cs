public class Startup
{
	public void Configuration(IAppBuilder app)
	{
		// Any connection or hub wire up and configuration should go here
		GlobalHost.DependencyResolver.UseRedis("server", port, "password", "AppName");
		app.MapSignalR();
	}
}