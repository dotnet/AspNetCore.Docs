#define PROD1  
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace WebMvcRouting.Controllers
{
#if PROD1
    #region snippet1
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
    #endregion

    public class MyProduct
    {
        public string Name { get; set; }
    }
#endif
}