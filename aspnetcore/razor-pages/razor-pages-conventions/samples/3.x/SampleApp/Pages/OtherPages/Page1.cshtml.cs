using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleApp.Pages.OtherPages
{
    public class Page1Model : PageModel
    {
        public string Message { get; private set; }

        public string RouteDataGlobalTemplateValue { get; private set; }

        public string RouteDataOtherPagesTemplateValue { get; private set; }

        public void OnGet()
        {
            Message = "Your application Page1 page.";

            #region snippet1
            if (RouteData.Values["globalTemplate"] != null)
            {
                RouteDataGlobalTemplateValue = $"Route data for 'globalTemplate' was provided: {RouteData.Values["globalTemplate"]}";
            }

            if (RouteData.Values["otherPagesTemplate"] != null)
            {
                RouteDataOtherPagesTemplateValue = $"Route data for 'otherPagesTemplate' was provided: {RouteData.Values["otherPagesTemplate"]}";
            }
            #endregion
        }
    }
}
