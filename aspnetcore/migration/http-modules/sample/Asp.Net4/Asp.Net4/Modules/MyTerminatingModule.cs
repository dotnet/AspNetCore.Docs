using System;
using System.Web;

namespace MyApp.Modules
{
    public class MyTerminatingModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            application.EndRequest += (new EventHandler(this.Application_EndRequest));
        }

        #region snippet_Terminate
        // ASP.NET 4 module that may terminate the request

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpContext context = ((HttpApplication)source).Context;

            // Do something with context near the beginning of request processing.

            if (TerminateRequest())
            {
                context.Response.End();
                return;
            }
        }
        #endregion

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpContext context = ((HttpApplication)source).Context;

            // Do something with context near the end of request processing.
        }

        private bool TerminateRequest()
        {
            return false;
        }
    }
}
