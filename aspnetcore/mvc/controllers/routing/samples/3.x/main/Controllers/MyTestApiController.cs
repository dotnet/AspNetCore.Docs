using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace WebMvcRouting.Controllers
{
    #region snippet
    public class MyApiControllerAttribute : Attribute, IRouteTemplateProvider
    {
        public string Template => "api/[controller]";

        public int? Order => 2;

        public string Name { get; set; }
    }

    [MyApiController]
    [ApiController]
    public class MyTestApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var order = ControllerContext.ActionDescriptor.AttributeRouteInfo.Order;
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            return Content($"Order = {order}, Template = {template}");
        }
    }
    #endregion
}
