using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    public class UrlTestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["url1"] = Url.Action("List", "Products0","" ,   protocol: Request.Scheme);
            ViewData["url2"] = Url.Action("Edit", "Products0", new { id = 17 }, protocol: Request.Scheme);
            ViewData["url3"] = Url.Action("List", "Products20", "", protocol: Request.Scheme);
            ViewData["url4"] = Url.Action("Edit", "Products20", new { id = 17 }, protocol: Request.Scheme);

            return View("TestLinks");
        }
    }
}