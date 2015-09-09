using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace UsingTagHelpers.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }

      public IActionResult About(string version = null)
      {
         ViewData["Message"] = System.Net.WebUtility.HtmlEncode(version);

         string view = null;

         switch (version)
         {
            case "th":
               view = "AboutTh";
               break;

               default:
               view = null;
               break;

         }


         return View(view);
      }

      public IActionResult Contact()
      {
         ViewData["Message"] = "Your contact page.";

         return View();
      }

      public IActionResult Error()
      {
         return View("~/Views/Shared/Error.cshtml");
      }
   }
}
