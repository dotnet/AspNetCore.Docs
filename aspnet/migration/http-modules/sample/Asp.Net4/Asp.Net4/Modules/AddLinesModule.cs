using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Asp.Net4.Modules
{
    public class AddLinesModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            application.EndRequest += (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            if (IsMvcRequest(context))
            {
                context.Response.Write("Added by BeginRequest handler in module AddLinesModule<hr>");
            }
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            if (IsMvcRequest(context))
            {
                context.Response.Write("<hr>Added by EndRequest handler in module AddLinesModule");
            }
        }

        private bool IsMvcRequest(HttpContext context)
        {
            string filePath = context.Request.FilePath;
            string fileExtension = VirtualPathUtility.GetExtension(filePath);

            bool isMvcRequest = string.IsNullOrEmpty(fileExtension);
            return isMvcRequest;
        }
    }
}
