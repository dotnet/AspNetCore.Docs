using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    #region snippet
    [ApiController]
    [Route("products")]
    public class ProductsApiController : Controller
    {
        [HttpGet]
        public IActionResult ListProducts()
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"template:{template} " +
                $" controller:{controllerName}  action name: {actionName}");
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id) {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"ID: {id} template:{template} " +
                $" controller:{controllerName}  action name: {actionName}");
        }
    }
    #endregion

#if PROD2
    // [Route("api/[controller]")] // Not needed because each method has a route template.
    #region snippet2
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        [HttpGet("/products/{id}", Name = "Products_List")]
        public ActionResult<string> GetProduct(int id)
        {
            var routeName = ControllerContext.ActionDescriptor.AttributeRouteInfo.Name;
            return $"GetProduct id: {id.ToString()} routeName: {routeName}";
        }
    }
    #endregion
#endif
}