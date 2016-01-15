using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace mvcOrderManagerSample.Controllers
{
    public class FinanceController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public override IActionResult Help()
        {
            return Redirect("https://specialsupportsite.example.com");
        }
    }
}
