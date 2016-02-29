using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace IntroToTagHelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(int id=0)
        {
            ViewData["Message"] = "Your application description page.";

            string view = "About";

            switch (id)
            {
                case 1:
                    view = "AboutImage";
                    break;

                case 2:
                    view = "AboutVoid";
                    break;

                case 0:
                default:
                    view = "About";
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
