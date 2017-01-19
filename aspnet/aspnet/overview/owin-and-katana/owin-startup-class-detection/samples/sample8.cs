using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IO;

//[assembly: OwinStartup(typeof(StartupDemo.Startup))]

namespace StartupDemo
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.Use((context, next) =>
         {
            TextWriter output = context.Get<TextWriter>("host.TraceOutput");
            return next().ContinueWith(result =>
            {
               output.WriteLine("Scheme {0} : Method {1} : Path {2} : MS {3}",
               context.Request.Scheme, context.Request.Method, context.Request.Path, getTime());
            });
         });

         app.Run(async context =>
         {
            await context.Response.WriteAsync(getTime() + " My First OWIN App");
         });
      }

      string getTime()
      {
         return DateTime.Now.Millisecond.ToString();
      }
   }
}