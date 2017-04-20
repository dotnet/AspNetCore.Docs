using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class WorkController : Controller
    {
        public DateTime Index()
        {
            return DateTime.Now;
        }
    }
}