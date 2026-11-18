#define PROD1
#define PROD2

using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace WebMvcRouting.Controllers
{
#if PROD1

    // <snippet>
    [ApiController]
    [Route("products")]
    public class ProductsApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListProducts()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
    // </snippet>
#endif

#if PROD2
    // <snippet2>
    [ApiController]
    public class Products2ApiController : ControllerBase
    {
        [HttpGet("/products2/{id}", Name = "Products_List")]
        public IActionResult GetProduct(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
    // </snippet2>
#endif
}
