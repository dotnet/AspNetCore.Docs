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

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            //return View("ContactCopy");
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
