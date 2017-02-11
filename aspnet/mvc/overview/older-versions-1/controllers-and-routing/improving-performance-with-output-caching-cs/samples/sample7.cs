using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ProfileController : Controller
    {
        [OutputCache(CacheProfile="Cache1Hour")]
        public string Index()
        {
            return DateTime.Now.ToString("T");
        }
    }
}