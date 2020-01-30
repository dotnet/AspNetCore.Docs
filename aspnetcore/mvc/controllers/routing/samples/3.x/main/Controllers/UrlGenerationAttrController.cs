//#define First
#if First
#region snippet_1
using Microsoft.AspNetCore.Mvc;

public class UrlGenerationAttrController : Controller
{
    [HttpGet("")]
    public IActionResult Source()
    {
        var url = Url.Action("Destination"); // Generates /custom/url/to/destination
        return Content($"Go check out {url}, it's really great.");
    }

    [HttpGet("custom/url/to/destination")]
    public IActionResult Destination() {
        var controllerName = ControllerContext.ActionDescriptor.ControllerName;
        var actionName = ControllerContext.ActionDescriptor.ActionName;
        var path = Request.Path.Value;
        return Content($"{controllerName} - {actionName} Path:{path}");
    }
}
#endregion
#endif