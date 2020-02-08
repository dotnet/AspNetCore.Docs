using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;


namespace WebMvcRouting.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        [HttpGet]   // GET /api/test2
        public IActionResult ListProducts()
        {
            return GetADinfo(ControllerContext.ActionDescriptor);
        }

        [HttpGet("{id}")]   // GET /api/test2/xyz
        public ActionResult GetProduct(string id)
        {
            return GetADinfo(ControllerContext.ActionDescriptor, id);
        }

        [HttpGet("int/{id:int}")] // GET /api/test2/int/3
        public ActionResult GetIntProduct(int id)
        {
            return GetADinfo(ControllerContext.ActionDescriptor, id.ToString());
        }

        [HttpGet("int2/{id}")]  // GET /api/test2/int2/3
        public ActionResult GetInt2Product(int id)
        {
            return GetADinfo(ControllerContext.ActionDescriptor, id.ToString());
        }

        private ContentResult GetADinfo(ControllerActionDescriptor actionDesc, string id = null)
        {
            var template = actionDesc.AttributeRouteInfo.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;
            var ids = (id == null) ? "" : $"id = {id}";

            return Content($"{ids} template:{template} {controllerName}.{actionName}");
        }
    }
    #endregion
}