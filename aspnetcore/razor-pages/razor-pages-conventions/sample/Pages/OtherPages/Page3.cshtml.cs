using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModelProvidersSample.Pages.OtherPages
{
    [ReplaceRouteValueFilter]
    public class Page3Model : PageModel
    {
        public string Message { get; private set; }

        public string RouteDataGlobalTemplateValue { get; private set; }

        public string RouteDataOtherPagesTemplateValue { get; private set; }

        public void Get()
        {
            Message = "Your application Page3 page.";

            if (RouteData.Values["globalTemplate"] != null)
            {
                RouteDataGlobalTemplateValue = $"Route data for 'globalTemplate' was provided: {RouteData.Values["globalTemplate"]}";
            }

            if (RouteData.Values["otherPagesTemplate"] != null)
            {
                RouteDataOtherPagesTemplateValue = $"Route data for 'otherPagesTemplate' was provided: {RouteData.Values["otherPagesTemplate"]}";
            }
        }
    }
}
