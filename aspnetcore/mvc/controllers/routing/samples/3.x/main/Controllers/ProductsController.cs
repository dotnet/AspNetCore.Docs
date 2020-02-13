//#define First
//#define Second
//#define Third
//#define Fourth
//#define Five
//#define Six
//#define SixX
//#define Seven
//#define Eight
//#define Nine


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;


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
            return GetADinfo(ControllerContext.ActionDescriptor);
        }

        #region snippet11
        [HttpGet("{id}")]
        public IActionResult Edit(int id) {
            #endregion
            return GetADinfo(ControllerContext.ActionDescriptor);
        }

        private ContentResult GetADinfo(ControllerActionDescriptor actionDesc)
        {
            var template = actionDesc.AttributeRouteInfo.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;

            return Content($" template:{template} {controllerName}.{actionName}");
        }
    }
    #endregion
    // Was products2 controller
#elif Second
    #region snippet20
    public class ProductsController : Controller
    {
        [HttpGet("[controller]/[action]")]  // Matches '/Products/List'
        public IActionResult List()
        {
            return GetADinfo(ControllerContext.ActionDescriptor);
        }

        [HttpGet("[controller]/[action]/{id}")]   // Matches '/Products/Edit/{id}'
        public IActionResult Edit(int id)
        {
            return GetADinfo(ControllerContext.ActionDescriptor);
        }
        #endregion
        private ContentResult GetADinfo(ControllerActionDescriptor actionDesc)
        {
            var template = actionDesc.AttributeRouteInfo.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;

            return Content($" template:{template} {controllerName}.{actionName}");
        }
    }
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
    public abstract class MyBaseController : ControllerBase
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
    // /api/products/edit/3
    // /api/products/list
    #region snippet5
    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class MyBaseController : ControllerBase
    {
    }

    public class ProductsController : MyBaseController
    {
        [HttpGet]
        public IActionResult List()
        {
            return GetADinfo(ControllerContext.ActionDescriptor);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            return GetADinfo(ControllerContext.ActionDescriptor, id.ToString());
        }
        #endregion

        private ContentResult GetADinfo(ControllerActionDescriptor actionDesc, string id = null)
        {
            var template = actionDesc.AttributeRouteInfo.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;
            var ids = (id == null) ? "" : $"id = {id}";

            return Content($"{ids} template:{template} {controllerName}.{actionName}");
        }
    }
#elif SixX
    #region snippet6x
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        [Route("")]     // Matches 'Products'
        [Route("Index")] // Matches 'Products/Index'
        public IActionResult Index()
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"template:{template} " +
                $" {controllerName}.{actionName}");
        }
    }
    #endregion
#elif Six
    #region snippet6
    [Route("Store")]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        [HttpPost("Buy")]       // Matches 'Products/Buy' and 'Store/Buy'
        [HttpPost("Checkout")]  // Matches 'Products/Checkout' and 'Store/Checkout'
        public IActionResult Buy()
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"template:{template} " +
                $" {controllerName}.{actionName}");
        }
    }
    #endregion
#elif Seven
    #region snippet7
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpPut("Buy")]        // Matches PUT 'api/Products/Buy'
        [HttpPost("Checkout")]  // Matches POST 'api/Products/Checkout'
        public IActionResult Buy()
        {
            var path = Request.Path.Value;
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"Path: {path} template:{template} " +
                $" {controllerName}.{actionName}");
        }
    }
    #endregion
#elif Eight
    // test with POST /product/3
    #region snippet8
    public class ProductsController : Controller
    {
        [HttpPost("product/{id:int}")]
        public IActionResult ShowProduct(int id)
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"ID: {id} template:{template} " +
                $" {controllerName}.{actionName}");
        }
    }
    #endregion
#elif Nine
    #region snippet9
    public class ProductsController : Controller
    {
        public IActionResult Edit(int id)
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"ID: {id} template:{template} " +
                $" {controllerName}.{actionName}");
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product) {

            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"ID: {id} template:{template} " +
                $" {controllerName}.{actionName}");
        }        
    }

    #endregion

    public class Product
    {
        public string name { get; set; }
    }
#endif
}
