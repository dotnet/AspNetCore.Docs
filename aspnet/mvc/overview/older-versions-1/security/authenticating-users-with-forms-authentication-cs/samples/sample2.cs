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

        
        [Authorize]
        public ActionResult CompanySecrets()
        {
            return View();
        }


        [Authorize(Users="Stephen")]
        public ActionResult StephenSecrets()
        {
            return View();
        }


        [Authorize(Roles = "Administrators")]
        public ActionResult AdministratorSecrets()
        {
            return View();
        }

    }
}