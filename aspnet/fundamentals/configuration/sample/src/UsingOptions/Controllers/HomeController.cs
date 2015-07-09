using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using UsingOptions.Models;

namespace UsingOptions.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<MyOptions> optionsAccessor)
        {
            Options = optionsAccessor.Options;
        }

        MyOptions Options { get; }

        public IActionResult Index()
        {
            return View(Options);
        }
    }
}
