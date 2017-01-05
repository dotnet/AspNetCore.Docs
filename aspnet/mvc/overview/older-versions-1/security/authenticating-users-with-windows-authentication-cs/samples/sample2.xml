using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Managers")]
        public ActionResult CompanySecrets()
        {
            return View();
        }

        [Authorize(Users="redmond\\swalther")]
        public ActionResult StephenSecrets()
        {
            return View();
        }



    }
}