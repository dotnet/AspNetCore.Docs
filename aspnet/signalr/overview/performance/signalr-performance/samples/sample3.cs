public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        // Any connection or hub wire up and configuration should go here
		GlobalHost.Configuration.DefaultMessageBufferSize = 500;
		app.MapSignalR();
    }
}