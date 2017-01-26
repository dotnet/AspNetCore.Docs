using System;
using System.Collections.Generic;
using System.Web;

namespace MvcApplication1.Models
{
    public class News
    {
        public static string RenderNews(HttpContext context)
        {
            var news = new List<string> 
                { 
                    "Gas prices go up!", 
                    "Life discovered on Mars!", 
                    "Moon disappears!" 
                };
            
            var rnd = new Random();
            return news[rnd.Next(news.Count)];
        }
    }
}