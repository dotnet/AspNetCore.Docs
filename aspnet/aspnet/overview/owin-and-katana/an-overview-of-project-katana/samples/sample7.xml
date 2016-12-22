public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        config.Routes.MapHttpRoute("default", "{controller}");
        app.UseWebApi(config);
    }
}