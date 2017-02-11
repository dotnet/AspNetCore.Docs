using Owin;
using System.Net;

namespace KatanaSelfHost
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpListener listener = 
                (HttpListener)app.Properties["System.Net.HttpListener"];
            listener.AuthenticationSchemes = 
                AuthenticationSchemes.IntegratedWindowsAuthentication;

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello World!");
            });
        }
    }
}