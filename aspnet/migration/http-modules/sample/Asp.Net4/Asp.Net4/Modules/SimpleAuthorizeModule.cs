using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Asp.Net4.Modules
{
    public class SimpleAuthorizeModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication application)
        {
            application.AuthorizeRequest += (new EventHandler(this.Application_AuthorizeRequest));
        }

        private void Application_AuthorizeRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            if (context.Request.QueryString["iamevil"] == "true")
            {
                context.Response.StatusCode = 403;
                context.Response.SuppressContent = true;
                context.Response.End();
                return;
            }
        }
    }
}
