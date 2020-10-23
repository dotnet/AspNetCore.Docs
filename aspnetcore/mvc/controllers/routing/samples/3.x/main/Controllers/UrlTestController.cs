using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    public class UrlTestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Products"] = Url.Action("Details", "Products", new { id = 17 }, protocol: Request.Scheme);
            ViewData["Products0"] = Url.Action("List", "Products0", null, protocol: Request.Scheme);
            ViewData["Products0 Edit"] = Url.Action("Edit", "Products0", new { id = 17 }, protocol: Request.Scheme);
            ViewData["Products20"] = Url.Action("List", "Products20", null, protocol: Request.Scheme);
            ViewData["Products20 Edit"] = Url.Action("Edit", "Products20", new { id = 17 }, protocol: Request.Scheme);
            ViewData["Products22"] = Url.Action("List", "Products22", null, protocol: Request.Scheme);
            ViewData["Products11"] = Url.Action("List", "Products11", null, protocol: Request.Scheme);
            ViewData["Products11 Edit"] = Url.Action("Edit", "Products11", new { id = 17 }, protocol: Request.Scheme);
            ViewData["Products13"] = Url.Action("", "Products13", null, protocol: Request.Scheme);
            ViewData["Products13 Index"] = Url.Action("Index", "Products13", null, protocol: Request.Scheme);
            ViewData["Products33"] = Url.Action("Edit", "Products33", new { id = 17 }, protocol: Request.Scheme);
            ViewData["MyProducts"] = Url.Action("ListProducts", "MyProducts", null, protocol: Request.Scheme);
            // <!--  review how does this even work? -->
            ViewData["MyTestApi"] = Url.Action("MyTestApi", "api", null, protocol: Request.Scheme);
            // <!--  review why doesn't this work? -->

            ViewData["MyTestApiController"] = Url.Action("Get", "MyTestApi", null, protocol: Request.Scheme);

            ViewData["ProductsApi"] = Url.Action("ListProducts", "ProductsApi", null, protocol: Request.Scheme);
            ViewData["ProductsApi ID"] = Url.Action("GetProduct", "ProductsApi", new { id = 17 }, protocol: Request.Scheme);
            ViewData["Products2Api"] = Url.Action("GetProduct", "Products2Api", new { id = 17 }, protocol: Request.Scheme);

            return View("TestLinks");
        }
    }
}