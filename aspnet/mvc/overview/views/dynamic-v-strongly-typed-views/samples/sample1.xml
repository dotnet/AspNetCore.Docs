using System.Collections.Generic;
using System.Web.Mvc;

namespace Mvc3ViewDemo.Controllers {

    public class Blog {
        public string Name;
        public string URL;
    }

    public class HomeController : Controller {

        List<Blog> topBlogs = new List<Blog>
      { 
          new Blog { Name = "ScottGu", URL = "http://weblogs.asp.net/scottgu/"},
          new Blog { Name = "Scott Hanselman", URL = "http://www.hanselman.com/blog/"},
          new Blog { Name = "Jon Galloway", URL = "http://www.asp.net/mvc"}
      };

        public ActionResult IndexNotStonglyTyped() {
            return View(topBlogs);
        }

        public ActionResult About() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }
    }
}