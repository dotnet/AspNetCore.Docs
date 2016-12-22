public class Startup
{
   public void Configuration(IAppBuilder app)
   {
      app.Use<LoggerMiddleware>(new TraceLogger());

      var config = new HttpConfiguration();
      // configure Web API 
      app.UseWebApi(config);

      // additional middleware registrations            
   }
}