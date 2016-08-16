using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CorsMVC.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class HomeController : Controller
    {
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Index()
        {
            return View();
        }

        [DisableCors]
        public IActionResult About()
        {
            return View();
        }
    }
}
