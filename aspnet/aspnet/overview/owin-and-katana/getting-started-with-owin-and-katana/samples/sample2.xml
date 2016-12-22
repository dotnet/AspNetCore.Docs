using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OwinApp.Startup1))]

namespace OwinApp
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
          app.Run(context =>
          {
              context.Response.ContentType = "text/plain";
              return context.Response.WriteAsync("Hello, world.");
          });
        }
    }
}