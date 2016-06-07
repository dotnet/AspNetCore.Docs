using System;
using Microsoft.AspNetCore.Mvc;
using AuthoringTagHelpers.Models;

namespace AuthoringTagHelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(bool approved = false)
        {
            return View(new WebsiteContext
            {
                Approved = approved,
                CopyrightYear = 2015,
                Version = new Version(1, 3, 3, 7),
                TagsToShow = 20
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            // return View("AboutBoldOnly");
            return View();
        }

        public IActionResult Contact(int id = 0)
        {
            ViewData["Message"] = "Your contact page.";

            string view = "Contact";

            switch (id)
            {
                case 1:
                    view = "ContactCopy";
                    break;

                case 2:
                    view = "ContactVoid";
                    break;

                case 0:
                default:
                    view = "Contact";
                    break;
            }
            return View(view);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
