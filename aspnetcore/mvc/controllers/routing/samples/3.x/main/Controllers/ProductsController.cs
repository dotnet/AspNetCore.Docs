 // #define First
//#define Second
//#define Third
//#define Fourth
#define Five

using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcRouting.Controllers
{
#if First
    #region snippet
    [Route("[controller]/[action]")]
    public class ProductsController : Controller
    {
    #region snippet10
        [HttpGet]
        public IActionResult List() {
    #endregion
            return View("Generic");
        }

    #region snippet11
        [HttpGet("{id}")]
        public IActionResult Edit(int id) {
    #endregion
            ViewData["Message"] = id.ToString();
            return View("Generic");
        }
    }
    #endregion
    // Was products2 controller
#elif Second
    #region snippet20
    public class ProductsController : Controller
    {
    #region snippet21
        [HttpGet("[controller]/[action]")]  // Matches '/Products/List'
        public IActionResult List()
        {
    #endregion
            return View("Generic");
        }

        [HttpGet("[controller]/[action]/{id}")]   // Matches '/Products/Edit/{id}'
        public IActionResult Edit(int id)
        {
            ViewData["Message"] = id.ToString();
            return View("Generic");
        }
    }
    #endregion
#elif Third
     [Route("[controller]")]
    public class ProductsController : Controller
    {
        [Route("")] // Matches 'Products'
        [Route("Index")] // Matches 'Products/Index'
        public IActionResult Index()
        {
            // ...
            return View("Generic");
        }
    }
#elif Fourth
    // Test with StartupAPI
    #region snippet4
    [ApiController]
    [Route("api/[controller]")]
    public abstract class MyBaseController : Controller
    {
    }

    public class ProductsController : MyBaseController
    {
        [HttpGet] // Matches '/api/Products'
        public IActionResult List()
        {
            return Content("Using BaseController List");
        }

        [HttpPut("{id}")] // Matches '/api/Products/{id}'
        public IActionResult Edit(int id)
        {
            return Content($"Using BaseController Edit/{id}");
        }
    }
    #endregion
#elif Five
    // Test with StartupDefaultMVC
    // TODO - routename is NULL - for /products/edit/4
    // Add routename
    #region snippet5
[Route("[controller]/[action]", Name = "[controller]_[action]")]
public class ProductsController : Controller
{
    [HttpGet]
    public IActionResult List()
    {
        var routeName = ControllerContext.ActionDescriptor.AttributeRouteInfo.Name;
        ViewData["Message"] = $"Route name: {routeName}";
        return View("Generic");
    }

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        var routeName = ControllerContext.ActionDescriptor.AttributeRouteInfo.Name;
        ViewData["Message"] = $"Route name: {routeName}, ID = {id.ToString()}";
        return View("Generic");
    }
}
    #endregion

/* The following works
    [HttpGet]
public IActionResult Edit2()
{
    var routeName = ControllerContext.ActionDescriptor.AttributeRouteInfo.Name;
    ViewData["Message"] = $"Route name: {routeName}";
    return View("Generic");
}
*/
#endif
}
 