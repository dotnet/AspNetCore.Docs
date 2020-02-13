//#define PROD1
//#define PROD2


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
            return GetADinfo(ControllerContext.ActionDescriptor);
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id) {
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
#endif
}