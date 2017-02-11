using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web;
using System.IO;
using Microsoft.Owin.Extensions;
[assembly: OwinStartup(typeof(owin2.Startup))]
namespace owin2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                PrintCurrentIntegratedPipelineStage(context, "Middleware 1");
                return next.Invoke();
            });
            app.Use((context, next) =>
            {
                PrintCurrentIntegratedPipelineStage(context, "2nd MW");
                return next.Invoke();
            }); 
            app.Run(context =>
            {
                PrintCurrentIntegratedPipelineStage(context, "3rd MW");
                return context.Response.WriteAsync("Hello world");
            });            
        }
        private void PrintCurrentIntegratedPipelineStage(IOwinContext context, string msg)
        {
            var currentIntegratedpipelineStage = HttpContext.Current.CurrentNotification;
            context.Get<TextWriter>("host.TraceOutput").WriteLine(
                "Current IIS event: " + currentIntegratedpipelineStage
                + " Msg: " + msg);
        }
    }
}