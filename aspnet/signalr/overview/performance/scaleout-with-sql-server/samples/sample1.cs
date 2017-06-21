public class Startup
{
    public void Configuration(IAppBuilder app)
    {
		// Any connection or hub wire up and configuration should go here
		string sqlConnectionString = "Connecton string to your SQL DB";
		GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);
		app.MapSignalR();
    }
}