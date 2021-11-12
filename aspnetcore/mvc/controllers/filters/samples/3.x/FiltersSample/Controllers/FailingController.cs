using System;
using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers
{
    // <snippet>
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class FailingController : Controller
    {
        [AddHeader("Failing Controller", 
                   "Won't appear when exception is handled")]
        public IActionResult Index()
        {
            throw new Exception("Testing custom exception filter.");
        }
    }
    // </snippet>
}