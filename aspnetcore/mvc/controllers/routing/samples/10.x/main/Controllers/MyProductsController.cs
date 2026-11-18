#define PROD1
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace WebMvcRouting.Controllers
{
#if PROD1
    // <snippet1>
    [ApiController]
    public class MyProductsController : ControllerBase
    {
        [HttpGet("/products3")]
        public IActionResult ListProducts()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        [HttpPost("/products3")]
        public IActionResult CreateProduct(MyProduct myProduct)
        {
            return ControllerContext.MyDisplayRouteInfo(myProduct.Name);
        }
    }
    // </snippet1>

    public class MyProduct
    {
        public string Name { get; set; } = string.Empty;
    }
#endif
}
