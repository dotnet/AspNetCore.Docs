using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcRouting.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Message"] = "BlogController index";
            return View();
        }
        public IActionResult Article()
        {
            ViewData["Message"] = "Article";
            return View();
        }
    }
}
