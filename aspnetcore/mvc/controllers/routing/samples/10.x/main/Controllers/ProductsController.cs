using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace WebMvcRouting.Controllers
{
    // <snippetA>
    public class ProductsController : Controller
    {
        public IActionResult Details(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
    // </snippetA>

    // <snippet>
    [Route("[controller]/[action]")]
    public class Products0Controller : Controller
    {
        // <snippet10>
        [HttpGet]
        public IActionResult List()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
        // </snippet10>


        // <snippet11>
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
        // </snippet11>
    }
    // </snippet>

    // <snippet20>
    public class Products20Controller : Controller
    {
        [HttpGet("[controller]/[action]")]  // Matches '/Products20/List'
        public IActionResult List()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        [HttpGet("[controller]/[action]/{id}")]   // Matches '/Products20/Edit/{id}'
        public IActionResult Edit(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
    // </snippet20>

    // TODO remove, apparently no snippet

    [Route("[controller]")]
    public class Products21Controller : Controller
    {
        [Route("")] // Matches 'Products21'
        [Route("Index")] // Matches 'Products21/Index'
        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }

    // Test with StartupAPI
    // <snippet4>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class MyBaseController : ControllerBase
    {
    }

    public class Products22Controller : MyBaseController
    {
        [HttpGet] //         GET /api/Products22
        public IActionResult List()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        [HttpPut("{id}")] //  PUT /api/Products22/3
        public IActionResult Edit(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
    // </snippet4>

    // <snippet5>
    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class MyBase2Controller : ControllerBase
    {
    }

    public class Products11Controller : MyBase2Controller
    {
        [HttpGet]                      // /api/products11/list
        public IActionResult List()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        [HttpGet("{id}")]             //    /api/products11/edit/3
        public IActionResult Edit(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
    // </snippet5>

    // <snippet6x>
    [Route("[controller]")]
    public class Products13Controller : Controller
    {
        [Route("")]     // Matches 'Products13'
        [Route("Index")] // Matches 'Products13/Index'
        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
        // </snippet6x>

        // test with POST /product/3
        // <snippet8>
        public class Products14Controller : Controller
        {
            [HttpPost("product14/{id:int}")]
            public IActionResult ShowProduct(int id)
            {
                return ControllerContext.MyDisplayRouteInfo(id);
            }
        }
        // </snippet8>



        // <snippet9>
        public class Products33Controller : Controller
        {
            public IActionResult Edit(int id)
            {
                return ControllerContext.MyDisplayRouteInfo(id);
            }

            [HttpPost]
            public IActionResult Edit(int id, Product product)
            {
                return ControllerContext.MyDisplayRouteInfo(id, product.name);
            }
        }
        // </snippet9>
    }

    public class Product
    {
        public string name { get; set; } = string.Empty;
    }


    // <snippet7>
    [Route("api/[controller]")]
    public class Products7Controller : ControllerBase
    {
        [HttpPut("Buy")]        // Matches PUT 'api/Products7/Buy'
        [HttpPost("Checkout")]  // Matches POST 'api/Products7/Checkout'
        public IActionResult Buy()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    // </snippet7>


    // <snippet6>
    [Route("Store")]
    [Route("[controller]")]
    public class Products6Controller : Controller
    {
        [HttpPost("Buy")]       // Matches 'Products6/Buy' and 'Store/Buy'
        [HttpPost("Checkout")]  // Matches 'Products6/Checkout' and 'Store/Checkout'
        public IActionResult Buy()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    // </snippet6>
}
