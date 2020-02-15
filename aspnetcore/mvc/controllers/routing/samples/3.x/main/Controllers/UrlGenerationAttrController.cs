using Microsoft.AspNetCore.Mvc;
#region snippet_1
public class UrlGenerationAttrController : Controller
{
    [HttpGet("custom")]
    public IActionResult Source()
    {
        var url = Url.Action("Destination");
        return ControllerContext.ToActionResult("", $" URL = {url}");
    }

    [HttpGet("custom/url/to/destination")]
    public IActionResult Destination() =>
            ControllerContext.ToActionResult();
}
#endregion