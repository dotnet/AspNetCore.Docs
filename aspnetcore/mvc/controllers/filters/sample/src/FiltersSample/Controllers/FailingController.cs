using System;
using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers
{
    [TypeFilter(typeof(CustomExceptionFilterAttribute))]
    public class FailingController : Controller
    {
        [AddHeader("FailingController", "This shouldn't appear if exception was handled.")]
        public IActionResult Index()
        {
            throw new Exception("Boom!");
        }
    }
}