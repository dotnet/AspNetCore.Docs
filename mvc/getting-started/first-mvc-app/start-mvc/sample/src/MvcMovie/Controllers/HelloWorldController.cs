#define VD

#if FIRST

using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.WebEncoders;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/ 

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}

#endif

#if Second
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.WebEncoders;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/ 

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.HtmlEncode(
                "Hello " + name + ", NumTimes is: " + numTimes);
        }
    }
}

#endif

#if Third
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.WebEncoders;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/ 

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.HtmlEncode(
                "Hello " + name + ", ID: " + ID);
        }
    }
}

#endif


#if View
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.WebEncoders;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/ 

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.HtmlEncode(
                "Hello " + name + ", ID: " + ID);
        }
    }
}

#endif

#if Index2
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.WebEncoders;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/ 

        public IActionResult Index()
        {
            return View("Index2");
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.HtmlEncode(
                "Hello " + name + ", ID: " + ID);
        }
    }
}

#endif

#if VD 


using Microsoft.AspNet.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}

#endif