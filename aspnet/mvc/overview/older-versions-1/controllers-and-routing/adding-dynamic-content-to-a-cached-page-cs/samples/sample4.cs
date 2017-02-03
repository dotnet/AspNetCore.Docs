using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Helpers
{
    public static class AdHelper
    {
        public static void RenderBanner(this HtmlHelper helper)
        {
            var context = helper.ViewContext.HttpContext;
            context.Response.WriteSubstitution(RenderBannerInternal);
        }
        
        private static string RenderBannerInternal(HttpContext context)
        {
            var ads = new List<string> 
                { 
                    "/ads/banner1.gif", 
                    "/ads/banner2.gif", 
                    "/ads/banner3.gif" 
                };

            var rnd = new Random();
            var ad = ads[rnd.Next(ads.Count)];
            return String.Format("<img src='{0}' />", ad);
        }
    }
}