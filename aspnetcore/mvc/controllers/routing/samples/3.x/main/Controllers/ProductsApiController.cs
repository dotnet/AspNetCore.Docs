//#define PROD1
#define PROD2

// TODO can we make these products4 and 5?

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace WebMvcRouting.Controllers
{
#if PROD1

    #region snippet
    [ApiController]
    [Route("products")]
    public class ProductsApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListProducts()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id) {
            return new CCAD().GetADinfo(ControllerContext, id);
        }
    }
    #endregion
#endif

#if PROD2
    // [Route("api/[controller]")] // Not needed because each method has a route template.
    #region snippet2
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        [HttpGet("/products/{id}", Name = "Products_List")]
        public ActionResult<string> GetProduct(int id)
        {
            return new CCAD().GetADinfo(ControllerContext, id);
        }       
    }
    #endregion
#endif
}