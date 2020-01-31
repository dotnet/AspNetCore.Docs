#region snippet_1
using Microsoft.AspNetCore.Mvc;

public class UrlGenerationAttrController : Controller
{
    [HttpGet("custom")]
    public IActionResult Source()
    {
        var url = Url.Action("Destination");
        return Content($"Url.Action link to Destination: {url}");
    }

    [HttpGet("custom/url/to/destination")]
    public IActionResult Destination()
    {
        var controllerName = ControllerContext.ActionDescriptor.ControllerName;
        var actionName = ControllerContext.ActionDescriptor.ActionName;
        var path = Request.Path.Value;
        return Content($"{controllerName} - {actionName} Path:{path}");
    }
}
#endregion