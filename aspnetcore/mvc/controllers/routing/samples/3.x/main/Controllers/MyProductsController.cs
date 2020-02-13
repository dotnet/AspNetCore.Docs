#define PROD1    // ProductsApiController use the same route so only one can be used.
using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
#if PROD1
    // [Route("api/[controller]")] // Not needed because each method has a route template.
    #region snippet1
    [ApiController]
    public class MyProductsController : ControllerBase
    {
        [HttpGet("/products3")]
        public ActionResult<string> ListProducts()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }

        [HttpPost("/products3")]
        public ActionResult<string> CreateProduct(MyProduct myProduct)
        {
            return new CCAD().GetADinfo(ControllerContext);
        }
    }
    #endregion

    public class MyProduct
    {
        public string Name { get; set; }
    }
#endif
}