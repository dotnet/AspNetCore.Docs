using Microsoft.AspNetCore.Mvc;

namespace RoutingSample.Snippets.Controllers;

// <snippet_ClassIndex>
public class WidgetController : ControllerBase
{
    private readonly LinkGenerator _linkGenerator;

    public WidgetController(LinkGenerator linkGenerator) =>
        _linkGenerator = linkGenerator;

    public IActionResult Index()
    {
        var indexPath = _linkGenerator.GetPathByAction(
            HttpContext, values: new { id = 17 })!;

        return Content(indexPath);
    }

    // ...
    // </snippet_ClassIndex>

    public IActionResult HomeSubscribe()
    {
        // <snippet_HomeSubscribe>
        var subscribePath = _linkGenerator.GetPathByAction(
            "Subscribe", "Home", new { id = 17 })!;
        // </snippet_HomeSubscribe>

        return Content(subscribePath);
    }

    public IActionResult WidgetSubscribe()
    {
        // <snippet_WidgetSubscribe>
        var subscribePath = _linkGenerator.GetPathByAction(
            HttpContext, "Subscribe", null, new { id = 17 });
        // </snippet_WidgetSubscribe>

        return Content(subscribePath!);
    }
}
