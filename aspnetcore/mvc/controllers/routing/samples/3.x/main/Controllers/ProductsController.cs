#define First
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
    #region snippet
    [Route("[controller]/[action]")]
    public class Products0Controller : Controller
    {
        #region snippet10
        [HttpGet]
        public IActionResult List() =>
            ControllerContext.ToActionResult();
        #endregion


        #region snippet11
        [HttpGet("{id}")]
        public IActionResult Edit(int id) =>
            ControllerContext.ToActionResult(id);
        #endregion
    }
    #endregion
    // Was products2 controller

    #region snippet20
    public class Products20Controller : Controller
    {
        [HttpGet("[controller]/[action]")]  // Matches '/Products20/List'
        public IActionResult List() =>
            ControllerContext.ToActionResult();

        [HttpGet("[controller]/[action]/{id}")]   // Matches '/Products20/Edit/{id}'
        public IActionResult Edit(int id) =>
            ControllerContext.ToActionResult(id);
    }
    #endregion

    // TODO remove, apparently no snippet

    [Route("[controller]")]
    public class Products21Controller : Controller
    {
        [Route("")] // Matches 'Products21'
        [Route("Index")] // Matches 'Products21/Index'
        public IActionResult Index() =>
            ControllerContext.ToActionResult();
    }

    // Test with StartupAPI
    #region snippet4
    [ApiController]
    [Route("api/[controller]")]
    public abstract class MyBaseController : ControllerBase
    {
    }

    public class Products22Controller : MyBaseController
    {
        [HttpGet] //         GET /api/Products22
        public IActionResult List()=>
            ControllerContext.ToActionResult();

        [HttpPut("{id}")] //  PUT /api/Products22/3
        public IActionResult Edit(int id) =>
            ControllerContext.ToActionResult(id);
    }
    #endregion

    #region snippet5
    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class MyBase2Controller : ControllerBase
    {
    }

    public class Products11Controller : MyBase2Controller
    {
        [HttpGet]                      // /api/products11/edit/3
        public IActionResult List() =>
            ControllerContext.ToActionResult();

        [HttpGet("{id}")]             //    /api/products11/edit/3
        public IActionResult Edit(int id) =>
            ControllerContext.ToActionResult(id);
    }
    #endregion

    #region snippet6x
    [Route("[controller]")]
    public class Products13Controller : Controller
    {
        [Route("")]     // Matches 'Products13'
        [Route("Index")] // Matches 'Products13/Index'
        public IActionResult Index() =>
            ControllerContext.ToActionResult();
    }
    #endregion

    // test with POST /product/3
#region snippet8
    public class Products14Controller : Controller
    {
        [HttpPost("product14/{id:int}")]
        public IActionResult ShowProduct(int id) =>
            ControllerContext.ToActionResult(id);
    }
    #endregion

#if Second


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


    #region snippet7
    [Route("api/[controller]")]
    public class Products7Controller : ControllerBase
    {
        [HttpPut("Buy")]        // Matches PUT 'api/Products7/Buy'
        [HttpPost("Checkout")]  // Matches POST 'api/Products7/Checkout'
        public IActionResult Buy() =>
            ControllerContext.ToActionResult();
    }
#endregion


#region snippet6
    [Route("Store")]
    [Route("[controller]")]
    public class Products6Controller : Controller
    {
        [HttpPost("Buy")]       // Matches 'Products6/Buy' and 'Store/Buy'
        [HttpPost("Checkout")]  // Matches 'Products6/Checkout' and 'Store/Checkout'
        public IActionResult Buy() =>
            ControllerContext.ToActionResult();
    }
#endregion
}
