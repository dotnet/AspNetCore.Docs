using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModelProvidersSample.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; private set; }

        public string RouteDataGlobalAttribute { get; private set; }

        public string RouteDataAboutAttribute { get; private set; }

        public void Get()
        {
            Message = $"Your application description page.";

            #region snippet1
            if (RouteData.Values["globalAttribute"] != null)
            {
                RouteDataGlobalAttribute = $"Route data for 'globalAttribute' was provided: {WebUtility.HtmlEncode(RouteData.Values["globalAttribute"].ToString())}";
            }
            #endregion

            #region snippet2
            if (RouteData.Values["aboutAttribute"] != null)
            {
                RouteDataAboutAttribute = $"Route data for 'aboutAttribute' was provided: {WebUtility.HtmlEncode(RouteData.Values["aboutAttribute"].ToString())}";
            }
            #endregion
        }
    }
}
