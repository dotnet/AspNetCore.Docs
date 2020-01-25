//#define PROD1    // Both use the same route so only one can be used.

using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
#if PROD1
    // [Route("api/[controller]")] // Not needed because each method has a route template.
    #region snippet
    [ApiController]
    public class MyProductsController : ControllerBase
    {
        [HttpGet("/products")]
        public ActionResult<string> ListProducts()
        {
            return "GET MyProductsController.ListProducts";
        }

        [HttpPost("/products")]
        public ActionResult<string> CreateProduct(MyProduct myProduct)
        {
            return $"POST CreateProduct {myProduct.Name}";
        }
    }
    #endregion

    public class MyProduct
    {
        public string Name { get; set; }
    }
#else
    // [Route("api/[controller]")] // Not needed because each method has a route template.
    #region snippet2
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        [HttpGet("/products/{id}", Name = "Products_List")]
        public ActionResult<string> GetProduct(int id)
        {
            return $"GetProduct {id.ToString()}";
        }
    }
    #endregion
#endif
}