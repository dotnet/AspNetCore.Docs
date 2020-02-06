using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleApp.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; private set; }

        public string RouteDataGlobalTemplateValue { get; private set; }

        public string RouteDataAboutTemplateValue { get; private set; }

        public void OnGet()
        {
            Message = "Your application description page.";

            #region snippet1
            if (RouteData.Values["globalTemplate"] != null)
            {
                RouteDataGlobalTemplateValue = $"Route data for 'globalTemplate' was provided: {RouteData.Values["globalTemplate"]}";
            }
            #endregion

            #region snippet2
            if (RouteData.Values["aboutTemplate"] != null)
            {
                RouteDataAboutTemplateValue = $"Route data for 'aboutTemplate' was provided: {RouteData.Values["aboutTemplate"]}";
            }
            #endregion
        }
    }
}
