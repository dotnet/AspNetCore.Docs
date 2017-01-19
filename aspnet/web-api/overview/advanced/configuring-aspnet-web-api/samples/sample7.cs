using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApplication1.Controllers
{

    public class UseMyFormatterAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings settings,
            HttpControllerDescriptor descriptor)
        {
            // Clear the formatters list.
            settings.Formatters.Clear();

            // Add a custom media-type formatter.
            settings.Formatters.Add(new MyFormatter());
        }
    }

    [UseMyFormatter]
    public class ValuesController : ApiController
    {
        // Controller methods not shown...
    }
}