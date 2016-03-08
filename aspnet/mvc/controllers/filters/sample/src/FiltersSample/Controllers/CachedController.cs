using System;
using FiltersSample.Filters;
using Microsoft.AspNet.Mvc;

namespace FiltersSample.Controllers
{
    [TypeFilter(typeof(NaiveCacheResourceFilterAttribute))]
    public class CachedController : Controller
    {
        public IActionResult Index()
        {
            return Content("This content was generated at " + DateTime.Now);
        }
    }
}
