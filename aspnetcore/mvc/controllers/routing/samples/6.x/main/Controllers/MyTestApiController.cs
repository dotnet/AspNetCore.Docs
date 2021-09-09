using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using Microsoft.Docs.Samples;

namespace WebMvcRouting.Controllers
{
    #region snippet
    public class MyApiControllerAttribute : Attribute, IRouteTemplateProvider
    {
        public string Template => "api/[controller]";
        public int? Order => 2;
        public string Name { get; set; } = string.Empty;
    }

    [MyApiController]
    [ApiController]
    public class MyTestApiController : ControllerBase
    {
        // GET /api/MyTestApi
        [HttpGet]
        public IActionResult Get()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    #endregion
}
